﻿/*
    eduVPN - End-user friendly VPN

    Copyright: 2017, The Commons Conservancy eduVPN Programme
    SPDX-License-Identifier: GPL-3.0+
*/

using System;
using System.Collections.Generic;
using System.Threading;

namespace eduVPN
{
    /// <summary>
    /// An eduVPN API endpoint
    /// </summary>
    public class API
    {
        #region Properties

        /// <summary>
        /// Authorization endpoint URI - used by the client to obtain authorization from the resource owner via user-agent redirection.
        /// </summary>
        public Uri AuthorizationEndpoint { get => _authorization_endpoint; }
        private Uri _authorization_endpoint;

        /// <summary>
        /// Token endpoint URI - used by the client to exchange an authorization grant for an access token, typically with client authentication.
        /// </summary>
        public Uri TokenEndpoint { get => _token_endpoint; }
        private Uri _token_endpoint;

        /// <summary>
        /// API base URI
        /// </summary>
        public Uri BaseURI { get => _base_uri; }
        private Uri _base_uri;

        /// <summary>
        /// Create client certificate URI
        /// </summary>
        public Uri CreateCertificate { get => _create_certificate; }
        private Uri _create_certificate;

        /// <summary>
        /// Profile configuration URI
        /// </summary>
        public Uri ProfileConfig { get => _profile_config; }
        private Uri _profile_config;

        /// <summary>
        /// Profile list URI
        /// </summary>
        public Uri ProfileList { get => _profile_list; }
        private Uri _profile_list;

        /// <summary>
        /// System messages URI
        /// </summary>
        public Uri SystemMessages { get => _system_messages; }
        private Uri _system_messages;

        /// <summary>
        /// User messages URI
        /// </summary>
        public Uri UserMessages { get => _user_messages; }
        private Uri _user_messages;

        #endregion

        #region Methods

        /// <summary>
        /// Loads APIv2 from a dictionary object (provided by JSON)
        /// </summary>
        /// <param name="obj">Key/value dictionary with <c>authorization_endpoint</c>, <c>token_endpoint</c> and other optional elements. All elements should be strings representing URI(s).</param>
        public void Load(Dictionary<string, object> obj)
        {
            // Set authorization endpoint.
            _authorization_endpoint = new Uri(eduJSON.Parser.GetValue<string>(obj, "authorization_endpoint"));

            // Set token endpoint.
            _token_endpoint = new Uri(eduJSON.Parser.GetValue<string>(obj, "token_endpoint"));

            // Set other URI(s).
            _base_uri = eduJSON.Parser.GetValue(obj, "api_base_uri", out string api_base_uri) ? new Uri(api_base_uri) : null;
            _create_certificate = eduJSON.Parser.GetValue(obj, "create_certificate", out string create_certificate) ? new Uri(create_certificate) : null;
            _profile_config = eduJSON.Parser.GetValue(obj, "profile_config", out string profile_config) ? new Uri(profile_config) : null;
            _profile_list = eduJSON.Parser.GetValue(obj, "profile_list", out string profile_list) ? new Uri(profile_list) : null;
            _system_messages = eduJSON.Parser.GetValue(obj, "system_messages", out string system_messages) ? new Uri(system_messages) : null;
            _user_messages = eduJSON.Parser.GetValue(obj, "user_messages", out string user_messages) ? new Uri(user_messages) : null;
        }

        /// <summary>
        /// Loads APIv2 from a JSON string
        /// </summary>
        /// <param name="json">JSON string</param>
        /// <param name="ct">The token to monitor for cancellation requests.</param>
        public void Load(string json, CancellationToken ct = default(CancellationToken))
        {
            Load(eduJSON.Parser.GetValue<Dictionary<string, object>>(
                eduJSON.Parser.GetValue<Dictionary<string, object>>(
                    (Dictionary<string, object>)eduJSON.Parser.Parse(json, ct),
                    "api"),
                "http://eduvpn.org/api#2"));
        }

        #endregion
    }
}
