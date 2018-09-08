// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Powershell.Http
{
    using System;
    using System.IO;
    using System.Management.Automation;
    using Microsoft.ServiceFabric.Client;

    /// <summary>
    /// Creates mesh secret resource in service fabric cluster.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "SFMeshSecret")]
    public class NewMeshSecretCmdlet : CommonCmdletBase
    {
        /// <summary>
        /// Gets or sets Secret name to create.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string SecretResourceName { get; set; }

        /// <summary>
        /// Gets or sets the json containing the description of the secret to be created.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "json")]
        public string JsonDescription { get; set; }

        /// <inheritdoc />
        protected override void ProcessRecordInternal()
        {
            var client = (IServiceFabricClient)this.SessionState.PSVariable.GetValue(Constants.ClusterConnectionVariableName);

            var secretResourceInfo = client.MeshSecrets.GetMeshSecretAsync(this.SecretResourceName, this.CancellationToken).GetAwaiter().GetResult();

            if (secretResourceInfo != null)
            {
                throw new InvalidOperationException("Specified mesh secret already exists in cluster. If you want to update it use Update-SFMeshSecret");
            }

            client.MeshSecrets.CreateOrUpdateMeshSecretAsync(
                secretResourceName: this.SecretResourceName,
                jsonDescription: this.JsonDescription,
                cancellationToken: this.CancellationToken).GetAwaiter().GetResult();
        }
    }
}