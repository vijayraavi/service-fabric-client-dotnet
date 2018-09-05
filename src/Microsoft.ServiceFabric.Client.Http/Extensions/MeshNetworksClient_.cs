// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.ServiceFabric.Client.Http.Serialization;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;

    internal partial class MeshNetworksClient : IMeshNetworksClient
    {
        /// <inheritdoc />
        public Task<VolumeResourceDescription> CreateOrUpdateMeshNetworkAsync(
            string networkResourceName,
            string jsonDescription,
            string apiVersion = Constants.DefaultApiVersionForResources,
            long? serverTimeout = 60,
            CancellationToken cancellationToken = default(CancellationToken))
        {            
            networkResourceName.ThrowIfNull(nameof(networkResourceName));
            jsonDescription.ThrowIfNull(nameof(jsonDescription));

            string requestId = Guid.NewGuid().ToString();
            var url = $"Resources/Networks/{networkResourceName}?api-version={apiVersion}";

            HttpRequestMessage RequestFunc()
            {
                var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    Content = new StringContent(jsonDescription, Encoding.UTF8),
                };
                request.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
                return request;
            }

            return this.httpClient.SendAsyncGetResponse(RequestFunc, url, VolumeResourceDescriptionConverter.Deserialize, requestId, cancellationToken);
        }
    }
}