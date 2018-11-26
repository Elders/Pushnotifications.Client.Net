﻿using System.Collections.Generic;

namespace PushNotifications.Client.Net
{
    public class DiscoveryReaderResponseModel
    {
        DiscoveryReaderResponseModel()
        {
            Endpoints = new List<DiscoverableEndpoint>();
        }

        public DiscoveryReaderResponseModel(long updatedAt, IEnumerable<DiscoverableEndpoint> endpoints)
        {
            UpdatedAt = updatedAt;
            Endpoints = new HashSet<DiscoverableEndpoint>(endpoints);
        }

        /// <summary>
        /// FileTimeUtc
        /// </summary>
        public long UpdatedAt { get; private set; }

        public IEnumerable<DiscoverableEndpoint> Endpoints { get; private set; }
    }
}
