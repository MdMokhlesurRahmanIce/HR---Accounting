using System;
using System.Collections;
using System.Reflection;

namespace ST
{
    public class DynamicallyMethodInvoker
    {
        /// <summary>
        /// Calling Syntax: IEnumerable iEnumerableResult = IEnumerable InvokeIEnumerableMethod ("TheProject", "TheNamespace", "TheClass", "TheMethod", "params");
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="namespaceName"></param>
        /// <param name="typeName"></param>
        /// <param name="methodName"></param>
        /// <param name="stringParams"></param>
        /// <returns></returns>
        public static IEnumerable InvokeIEnumerableMethod(string assemblyName, string namespaceName, string typeName, string methodName, params string[] stringParams)
        {
            // Get the Type for the class
            Type calledType = Type.GetType(namespaceName + "." + typeName + "," + assemblyName);

            // Invoke the method itself. The string returned by the method winds up in s
            IEnumerable iEnumerableResult = (IEnumerable)calledType.InvokeMember(
                            methodName,
                            BindingFlags.InvokeMethod | BindingFlags.Public |
                                BindingFlags.Static,
                            null,
                            null,
                            stringParams);

            // Return the string that was returned by the called method.
            return iEnumerableResult;
        }
    }
}
