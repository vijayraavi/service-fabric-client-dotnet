// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converter for <see cref="ApplicationScopedVolume" />.
    /// </summary>
    internal class ApplicationScopedVolumeConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationScopedVolume Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationScopedVolume GetFromJsonProperties(JsonReader reader)
        {
            var name = default(string);
            var readOnly = default(bool?);
            var destinationPath = default(string);
            var creationParameters = default(ApplicationScopedVolumeCreationParameters);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("name", propName, StringComparison.Ordinal) == 0)
                {
                    name = reader.ReadValueAsString();
                }
                else if (string.Compare("readOnly", propName, StringComparison.Ordinal) == 0)
                {
                    readOnly = reader.ReadValueAsBool();
                }
                else if (string.Compare("destinationPath", propName, StringComparison.Ordinal) == 0)
                {
                    destinationPath = reader.ReadValueAsString();
                }
                else if (string.Compare("creationParameters", propName, StringComparison.Ordinal) == 0)
                {
                    creationParameters = ApplicationScopedVolumeCreationParametersConverter.Deserialize(reader);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ApplicationScopedVolume(
                name: name,
                readOnly: readOnly,
                destinationPath: destinationPath,
                creationParameters: creationParameters);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ApplicationScopedVolume obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Name, "name", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.DestinationPath, "destinationPath", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.CreationParameters, "creationParameters", ApplicationScopedVolumeCreationParametersConverter.Serialize);
            if (obj.ReadOnly != null)
            {
                writer.WriteProperty(obj.ReadOnly, "readOnly", JsonWriterExtensions.WriteBoolValue);
            }

            writer.WriteEndObject();
        }
    }
}
