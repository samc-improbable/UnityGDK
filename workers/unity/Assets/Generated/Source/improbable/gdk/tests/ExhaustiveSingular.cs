// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using Unity.Entities;
using Improbable.Gdk.Core;

namespace Generated.Improbable.Gdk.Tests
{
    public partial class ExhaustiveSingular
    {
        public struct Component : IComponentData, ISpatialComponentData
        {
            public uint ComponentId => 197715;

            public BlittableBool DirtyBit { get; set; }

            private BlittableBool field1;

            public BlittableBool Field1
            {
                get => field1;
                set
                {
                    DirtyBit = true;
                    field1 = value;
                }
            }

            private float field2;

            public float Field2
            {
                get => field2;
                set
                {
                    DirtyBit = true;
                    field2 = value;
                }
            }

            internal uint field3Handle;

            public byte[] Field3
            {
                get => Generated.Improbable.Gdk.Tests.ExhaustiveSingular.ReferenceTypeProviders.Field3Provider.Get(field3Handle);
                set
                {
                    DirtyBit = true;
                    Generated.Improbable.Gdk.Tests.ExhaustiveSingular.ReferenceTypeProviders.Field3Provider.Set(field3Handle, value);
                }
            }

            private int field4;

            public int Field4
            {
                get => field4;
                set
                {
                    DirtyBit = true;
                    field4 = value;
                }
            }

            private long field5;

            public long Field5
            {
                get => field5;
                set
                {
                    DirtyBit = true;
                    field5 = value;
                }
            }

            private double field6;

            public double Field6
            {
                get => field6;
                set
                {
                    DirtyBit = true;
                    field6 = value;
                }
            }

            internal uint field7Handle;

            public string Field7
            {
                get => Generated.Improbable.Gdk.Tests.ExhaustiveSingular.ReferenceTypeProviders.Field7Provider.Get(field7Handle);
                set
                {
                    DirtyBit = true;
                    Generated.Improbable.Gdk.Tests.ExhaustiveSingular.ReferenceTypeProviders.Field7Provider.Set(field7Handle, value);
                }
            }

            private uint field8;

            public uint Field8
            {
                get => field8;
                set
                {
                    DirtyBit = true;
                    field8 = value;
                }
            }

            private ulong field9;

            public ulong Field9
            {
                get => field9;
                set
                {
                    DirtyBit = true;
                    field9 = value;
                }
            }

            private int field10;

            public int Field10
            {
                get => field10;
                set
                {
                    DirtyBit = true;
                    field10 = value;
                }
            }

            private long field11;

            public long Field11
            {
                get => field11;
                set
                {
                    DirtyBit = true;
                    field11 = value;
                }
            }

            private uint field12;

            public uint Field12
            {
                get => field12;
                set
                {
                    DirtyBit = true;
                    field12 = value;
                }
            }

            private ulong field13;

            public ulong Field13
            {
                get => field13;
                set
                {
                    DirtyBit = true;
                    field13 = value;
                }
            }

            private int field14;

            public int Field14
            {
                get => field14;
                set
                {
                    DirtyBit = true;
                    field14 = value;
                }
            }

            private long field15;

            public long Field15
            {
                get => field15;
                set
                {
                    DirtyBit = true;
                    field15 = value;
                }
            }

            private global::Improbable.Worker.EntityId field16;

            public global::Improbable.Worker.EntityId Field16
            {
                get => field16;
                set
                {
                    DirtyBit = true;
                    field16 = value;
                }
            }

            private global::Generated.Improbable.Gdk.Tests.SomeType field17;

            public global::Generated.Improbable.Gdk.Tests.SomeType Field17
            {
                get => field17;
                set
                {
                    DirtyBit = true;
                    field17 = value;
                }
            }

            public static global::Improbable.Worker.Core.ComponentData CreateSchemaComponentData(
                BlittableBool field1,
                float field2,
                byte[] field3,
                int field4,
                long field5,
                double field6,
                string field7,
                uint field8,
                ulong field9,
                int field10,
                long field11,
                uint field12,
                ulong field13,
                int field14,
                long field15,
                global::Improbable.Worker.EntityId field16,
                global::Generated.Improbable.Gdk.Tests.SomeType field17
        )
            {
                var schemaComponentData = new global::Improbable.Worker.Core.SchemaComponentData(197715);
                var obj = schemaComponentData.GetFields();
                {
                    obj.AddBool(1, field1);
                }
                {
                    obj.AddFloat(2, field2);
                }
                {
                    obj.AddBytes(3, field3);
                }
                {
                    obj.AddInt32(4, field4);
                }
                {
                    obj.AddInt64(5, field5);
                }
                {
                    obj.AddDouble(6, field6);
                }
                {
                    obj.AddString(7, field7);
                }
                {
                    obj.AddUint32(8, field8);
                }
                {
                    obj.AddUint64(9, field9);
                }
                {
                    obj.AddSint32(10, field10);
                }
                {
                    obj.AddSint64(11, field11);
                }
                {
                    obj.AddFixed32(12, field12);
                }
                {
                    obj.AddFixed64(13, field13);
                }
                {
                    obj.AddSfixed32(14, field14);
                }
                {
                    obj.AddSfixed64(15, field15);
                }
                {
                    obj.AddEntityId(16, field16);
                }
                {
                    global::Generated.Improbable.Gdk.Tests.SomeType.Serialization.Serialize(field17, obj.AddObject(17));
                }
                return new global::Improbable.Worker.Core.ComponentData(schemaComponentData);
            }
        }

        public static class Serialization
        {
            public static void Serialize(Generated.Improbable.Gdk.Tests.ExhaustiveSingular.Component component, global::Improbable.Worker.Core.SchemaObject obj)
            {
                {
                    obj.AddBool(1, component.Field1);
                }
                {
                    obj.AddFloat(2, component.Field2);
                }
                {
                    obj.AddBytes(3, component.Field3);
                }
                {
                    obj.AddInt32(4, component.Field4);
                }
                {
                    obj.AddInt64(5, component.Field5);
                }
                {
                    obj.AddDouble(6, component.Field6);
                }
                {
                    obj.AddString(7, component.Field7);
                }
                {
                    obj.AddUint32(8, component.Field8);
                }
                {
                    obj.AddUint64(9, component.Field9);
                }
                {
                    obj.AddSint32(10, component.Field10);
                }
                {
                    obj.AddSint64(11, component.Field11);
                }
                {
                    obj.AddFixed32(12, component.Field12);
                }
                {
                    obj.AddFixed64(13, component.Field13);
                }
                {
                    obj.AddSfixed32(14, component.Field14);
                }
                {
                    obj.AddSfixed64(15, component.Field15);
                }
                {
                    obj.AddEntityId(16, component.Field16);
                }
                {
                    global::Generated.Improbable.Gdk.Tests.SomeType.Serialization.Serialize(component.Field17, obj.AddObject(17));
                }
            }

            public static Generated.Improbable.Gdk.Tests.ExhaustiveSingular.Component Deserialize(global::Improbable.Worker.Core.SchemaObject obj, global::Unity.Entities.World world)
            {
                var component = new Generated.Improbable.Gdk.Tests.ExhaustiveSingular.Component();

                {
                    component.Field1 = obj.GetBool(1);
                }
                {
                    component.Field2 = obj.GetFloat(2);
                }
                component.field3Handle = Generated.Improbable.Gdk.Tests.ExhaustiveSingular.ReferenceTypeProviders.Field3Provider.Allocate(world);
                {
                    component.Field3 = obj.GetBytes(3);
                }
                {
                    component.Field4 = obj.GetInt32(4);
                }
                {
                    component.Field5 = obj.GetInt64(5);
                }
                {
                    component.Field6 = obj.GetDouble(6);
                }
                component.field7Handle = Generated.Improbable.Gdk.Tests.ExhaustiveSingular.ReferenceTypeProviders.Field7Provider.Allocate(world);
                {
                    component.Field7 = obj.GetString(7);
                }
                {
                    component.Field8 = obj.GetUint32(8);
                }
                {
                    component.Field9 = obj.GetUint64(9);
                }
                {
                    component.Field10 = obj.GetSint32(10);
                }
                {
                    component.Field11 = obj.GetSint64(11);
                }
                {
                    component.Field12 = obj.GetFixed32(12);
                }
                {
                    component.Field13 = obj.GetFixed64(13);
                }
                {
                    component.Field14 = obj.GetSfixed32(14);
                }
                {
                    component.Field15 = obj.GetSfixed64(15);
                }
                {
                    component.Field16 = obj.GetEntityId(16);
                }
                {
                    component.Field17 = global::Generated.Improbable.Gdk.Tests.SomeType.Serialization.Deserialize(obj.GetObject(17));
                }
                return component;
            }

            public static Generated.Improbable.Gdk.Tests.ExhaustiveSingular.Update GetAndApplyUpdate(global::Improbable.Worker.Core.SchemaObject obj, ref Generated.Improbable.Gdk.Tests.ExhaustiveSingular.Component component)
            {
                var update = new Generated.Improbable.Gdk.Tests.ExhaustiveSingular.Update();
                {
                    if (obj.GetBoolCount(1) == 1)
                    {
                        var value = obj.GetBool(1);
                        component.Field1 = value;
                        update.Field1 = new global::Improbable.Gdk.Core.Option<BlittableBool>(value);
                    }
                    
                }
                {
                    if (obj.GetFloatCount(2) == 1)
                    {
                        var value = obj.GetFloat(2);
                        component.Field2 = value;
                        update.Field2 = new global::Improbable.Gdk.Core.Option<float>(value);
                    }
                    
                }
                {
                    if (obj.GetBytesCount(3) == 1)
                    {
                        var value = obj.GetBytes(3);
                        component.Field3 = value;
                        update.Field3 = new global::Improbable.Gdk.Core.Option<byte[]>(value);
                    }
                    
                }
                {
                    if (obj.GetInt32Count(4) == 1)
                    {
                        var value = obj.GetInt32(4);
                        component.Field4 = value;
                        update.Field4 = new global::Improbable.Gdk.Core.Option<int>(value);
                    }
                    
                }
                {
                    if (obj.GetInt64Count(5) == 1)
                    {
                        var value = obj.GetInt64(5);
                        component.Field5 = value;
                        update.Field5 = new global::Improbable.Gdk.Core.Option<long>(value);
                    }
                    
                }
                {
                    if (obj.GetDoubleCount(6) == 1)
                    {
                        var value = obj.GetDouble(6);
                        component.Field6 = value;
                        update.Field6 = new global::Improbable.Gdk.Core.Option<double>(value);
                    }
                    
                }
                {
                    if (obj.GetStringCount(7) == 1)
                    {
                        var value = obj.GetString(7);
                        component.Field7 = value;
                        update.Field7 = new global::Improbable.Gdk.Core.Option<string>(value);
                    }
                    
                }
                {
                    if (obj.GetUint32Count(8) == 1)
                    {
                        var value = obj.GetUint32(8);
                        component.Field8 = value;
                        update.Field8 = new global::Improbable.Gdk.Core.Option<uint>(value);
                    }
                    
                }
                {
                    if (obj.GetUint64Count(9) == 1)
                    {
                        var value = obj.GetUint64(9);
                        component.Field9 = value;
                        update.Field9 = new global::Improbable.Gdk.Core.Option<ulong>(value);
                    }
                    
                }
                {
                    if (obj.GetSint32Count(10) == 1)
                    {
                        var value = obj.GetSint32(10);
                        component.Field10 = value;
                        update.Field10 = new global::Improbable.Gdk.Core.Option<int>(value);
                    }
                    
                }
                {
                    if (obj.GetSint64Count(11) == 1)
                    {
                        var value = obj.GetSint64(11);
                        component.Field11 = value;
                        update.Field11 = new global::Improbable.Gdk.Core.Option<long>(value);
                    }
                    
                }
                {
                    if (obj.GetFixed32Count(12) == 1)
                    {
                        var value = obj.GetFixed32(12);
                        component.Field12 = value;
                        update.Field12 = new global::Improbable.Gdk.Core.Option<uint>(value);
                    }
                    
                }
                {
                    if (obj.GetFixed64Count(13) == 1)
                    {
                        var value = obj.GetFixed64(13);
                        component.Field13 = value;
                        update.Field13 = new global::Improbable.Gdk.Core.Option<ulong>(value);
                    }
                    
                }
                {
                    if (obj.GetSfixed32Count(14) == 1)
                    {
                        var value = obj.GetSfixed32(14);
                        component.Field14 = value;
                        update.Field14 = new global::Improbable.Gdk.Core.Option<int>(value);
                    }
                    
                }
                {
                    if (obj.GetSfixed64Count(15) == 1)
                    {
                        var value = obj.GetSfixed64(15);
                        component.Field15 = value;
                        update.Field15 = new global::Improbable.Gdk.Core.Option<long>(value);
                    }
                    
                }
                {
                    if (obj.GetEntityIdCount(16) == 1)
                    {
                        var value = obj.GetEntityId(16);
                        component.Field16 = value;
                        update.Field16 = new global::Improbable.Gdk.Core.Option<global::Improbable.Worker.EntityId>(value);
                    }
                    
                }
                {
                    if (obj.GetObjectCount(17) == 1)
                    {
                        var value = global::Generated.Improbable.Gdk.Tests.SomeType.Serialization.Deserialize(obj.GetObject(17));
                        component.Field17 = value;
                        update.Field17 = new global::Improbable.Gdk.Core.Option<global::Generated.Improbable.Gdk.Tests.SomeType>(value);
                    }
                    
                }
                return update;
            }
        }

        public struct Update : ISpatialComponentUpdate
        {
            public Option<BlittableBool> Field1;
            public Option<float> Field2;
            public Option<byte[]> Field3;
            public Option<int> Field4;
            public Option<long> Field5;
            public Option<double> Field6;
            public Option<string> Field7;
            public Option<uint> Field8;
            public Option<ulong> Field9;
            public Option<int> Field10;
            public Option<long> Field11;
            public Option<uint> Field12;
            public Option<ulong> Field13;
            public Option<int> Field14;
            public Option<long> Field15;
            public Option<global::Improbable.Worker.EntityId> Field16;
            public Option<global::Generated.Improbable.Gdk.Tests.SomeType> Field17;
        }

        public struct ReceivedUpdates : IComponentData
        {
            internal uint handle;
            public global::System.Collections.Generic.List<Update> Updates
            {
                get => Generated.Improbable.Gdk.Tests.ExhaustiveSingular.ReferenceTypeProviders.UpdatesProvider.Get(handle);
            }
        }
    }
}
