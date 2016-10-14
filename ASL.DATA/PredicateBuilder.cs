using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;

namespace ASL.DATA
    {
    public class PredicateBuilder
        {
        public static Predicate<T> Build<T>(String Expression)
            {
            //String[] tokens = Expression.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            //int i = 0;
            //foreach (String str in tokens)
            //{
            //    if (i % 4 == 0)
            //    {
            //        Expression = Expression.Replace(str, String.Format("item.{0}", str));
            //    }
            //    i++;
            //}

            Type type = typeof(T);

            String[] assLocation = { type.Assembly.Location, type.BaseType.Assembly.Location };

            String returnString = "return ";
            returnString += Expression.Replace("$", "\"").Replace(" And ", " && ").Replace(" and ", " && ").Replace(" AND ", " && ");
            returnString = returnString.Replace(" or ", " || ").Replace(" OR ", " || ").Replace(" Or ", " || ").Replace(" oR ", " || ");
            returnString = returnString.Replace("<>", "!=");

            //build the dynamic assembly for the predicate
            String predicateTypeName = String.Format("Predicate<{0}>", type.FullName);
            String code = "using System; using System.Collections.Generic; namespace Dummy { public class Match { public static Boolean MatchFunc(" + type.FullName + " item) { " + returnString + "; } public static Predicate<" + type.FullName + "> MatchPred = new Predicate<" + type.FullName + ">(Match.MatchFunc); public static Predicate<" + type.FullName + "> GetPredicate() { return Match.MatchPred; } } }";
            Assembly dynAsm = BuildAssembly(code, assLocation);

            //call the GetPredicate method to get an instance of the predicate
            Type matchClassType = dynAsm.GetType("Dummy.Match");

            MethodInfo getPredicateInfo = matchClassType.GetMethod("GetPredicate");

            return (Predicate<T>)getPredicateInfo.Invoke(null, null);
            }

        private static Assembly BuildAssembly(String code, String[] assLocation)
            {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters compilerparams = new CompilerParameters();
            compilerparams.GenerateExecutable = false;
            compilerparams.GenerateInMemory = true;
            //AssemblyName[] asms = Assembly.GetExecutingAssembly().GetReferencedAssemblies();            

            //foreach (AssemblyName asName in asms)
            //    if(asName.Name != "System.Core")
            //        compilerparams.ReferencedAssemblies.Add(asName.Name + ".dll");


            compilerparams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerparams.ReferencedAssemblies.Add("System.dll");
            compilerparams.ReferencedAssemblies.Add("System.Data.dll");
            compilerparams.ReferencedAssemblies.Add(assLocation[0]);
            compilerparams.ReferencedAssemblies.Add(assLocation[1]);


            //Add reference to the current application in case types are defined in the .exe
            //rather than a class library
            //compilerparams.ReferencedAssemblies.Add(Assembly.GetEntryAssembly().ManifestModule.Name);


            CompilerResults results = provider.CompileAssemblyFromSource(compilerparams, code);

            if (results.Errors.HasErrors)
                {
                StringBuilder errors = new StringBuilder("Compiler Errors :\r\n");
                foreach (CompilerError error in results.Errors)
                    {
                    errors.AppendFormat("Line {0},{1}\t: {2}\n",
                        error.Line, error.Column, error.ErrorText);
                    }
                throw new ApplicationException(errors.ToString());
                }
            else
                {
                return results.CompiledAssembly;
                }
            }
        }
    }
