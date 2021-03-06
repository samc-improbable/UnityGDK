using System.Collections.Generic;
using Improbable.CodeGeneration.Model;
using Improbable.CodeGeneration.Utils;

namespace Improbable.Gdk.CodeGenerator
{
    public class UnityFieldDetails
    {
        public string Type => fieldType.Type;
        public string PascalCaseName => Formatting.SnakeCaseToCapitalisedCamelCase(rawFieldDefinition.name);
        public string CamelCaseName => Formatting.SnakeCaseToCamelCase(rawFieldDefinition.name);
        public int FieldNumber => rawFieldDefinition.Number;
        public bool IsBlittable;

        private IFieldType fieldType;
        private FieldDefinitionRaw rawFieldDefinition;

        public UnityFieldDetails(FieldDefinitionRaw rawFieldDefinition, bool isBlittable, HashSet<string> enumSet)
        {
            this.rawFieldDefinition = rawFieldDefinition;
            IsBlittable = isBlittable;

            if (rawFieldDefinition.IsOption())
            {
                fieldType = new OptionFieldType(rawFieldDefinition.optionType, enumSet);
            }
            else if (rawFieldDefinition.IsList())
            {
                fieldType = new ListFieldType(rawFieldDefinition.listType, enumSet);
            }
            else if (rawFieldDefinition.IsMap())
            {
                fieldType = new MapFieldType(rawFieldDefinition.mapType, enumSet);
            }
            else
            {
                fieldType = new SingularFieldType(rawFieldDefinition.singularType, enumSet);
            }
        }
        
        /// <summary>
        ///     Helper function that returns a (multi-line) string that represents the C# code required to serialize
        ///     this field.
        /// </summary>
        /// <param name="fieldInstance">The name of the instance of this field that is to be serialized.</param>
        /// <param name="schemaObject">The name of the SchemaObject is to be used in serialization.</param>
        /// <param name="indents">The indent level that the block of code should be at.</param>
        public string GetSerializationString(string fieldInstance, string schemaObject, int indents)
        {
            return fieldType.GetSerializationString(fieldInstance, schemaObject, FieldNumber, indents);
        }
        
        /// <summary>
        ///     Helper function that returns a (multi-line) string that represents the C# code required to deserialize 
        ///     this field on a ComponentData object. 
        /// </summary>
        /// <param name="fieldInstance">The name of the instance of this field that is being deserialized into.</param>
        /// <param name="schemaObject">The name of the SchemaObject is to be used in deserialization.</param>
        /// <param name="indents">The indent level that the block of code should be at.</param>
        public string GetDeserializeString(string fieldInstance, string schemaObject, int indents)
        {
            return fieldType.GetDeserializationString(fieldInstance, schemaObject, FieldNumber, indents);
        }
        
        /// <summary>
        ///     Helper function that returns a (multi-line) string that represents the C# code required to deserialize 
        ///     this field on a ComponentUpdate object. 
        /// </summary>
        /// <param name="fieldInstance">The name of the instance of this field that is being deserialized into.</param>
        /// <param name="updateInstance">
        ///     The name of the instance of this field on the update object that is being
        ///     deserialized into.
        /// </param>
        /// <param name="schemaObject">The name of the SchemaObject is to be used in deserialization.</param>
        /// <param name="indents">The indent level that the block of code should be at.</param>
        /// <returns></returns>
        public string GetDeserializeUpdateString(string fieldInstance, string updateInstance, string schemaObject, int indents)
        {
            return fieldType.GetDeserializeUpdateString(fieldInstance, updateInstance, schemaObject, FieldNumber,
                indents);
        }
    }
}
