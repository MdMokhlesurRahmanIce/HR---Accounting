using System;

namespace ASL.DATA
{
    // Summary:
    //     Gets the state of a Item object.
    [Flags]
    public enum ItemState
    {
        // Summary:
        //     The row has been created but is not part of any ItemCollection.
        //     A System.Data.DataRow is in this state immediately after it has been created
        //     and before it is added to a collection, or if it has been removed from a
        //     collection.
        Detached = 1,
        //
        // Summary:
        //     The row has not changed since Item.AcceptChanges() was last
        //     called.
        Unchanged = 2,
        //
        // Summary:
        //     The row has been added to a ItemCollection, and Item.AcceptChanges()
        //     has not been called.
        Added = 3,
        //
        // Summary:
        //     The row was deleted using the Item.Delete() method of the
        //     ASL.DATA;.Item.
        Deleted = 4,
        //
        // Summary:
        //     The row has been modified and Item.AcceptChanges() has not
        //     been called.
        Modified = 5,
    }

    // Summary:
    //     Gets the state of a Item object.
    [Flags]
    public enum SchemaTableColumnInfo
    {
        IsKey = 1,
        ColumnName = 2,
        BaseTableName = 3,
        IsIdentity = 4,
    }
    [Flags]
    public enum FieldCategory
    {
        PrimaryField = 1,
        IdentityField = 1,
        NormalField = 2,
        DummyField = 3,
        PrimaryIdentityField = 4,
    }
}
