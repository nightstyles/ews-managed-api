// ---------------------------------------------------------------------------
// <copyright file="GetPasswordExpirationDateRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------

//-----------------------------------------------------------------------
// <summary>Defines the GetPasswordExpirationDateRequest class.</summary>
//-----------------------------------------------------------------------

namespace Microsoft.Exchange.WebServices.Data
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents a GetPasswordExpirationDate request.
    /// </summary>
    internal sealed class GetPasswordExpirationDateRequest : SimpleServiceRequestBase, IJsonSerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPasswordExpirationDateRequest"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        internal GetPasswordExpirationDateRequest(ExchangeService service)
            : base(service)
        {
        }

        /// <summary>
        /// Gets the name of the XML element.
        /// </summary>
        /// <returns>XML element name.</returns>
        internal override string GetXmlElementName()
        {
            return XmlElementNames.GetPasswordExpirationDateRequest;
        }

        /// <summary>
        /// Writes XML elements.
        /// </summary>
        /// <param name="writer">The writer.</param>
        internal override void WriteElementsToXml(EwsServiceXmlWriter writer)
        {
            writer.WriteElementValue(XmlNamespace.Messages, XmlElementNames.MailboxSmtpAddress, this.MailboxSmtpAddress);
        }

        /// <summary>
        /// Creates a JSON representation of this object.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>
        /// A Json value (either a JsonObject, an array of Json values, or a Json primitive)
        /// </returns>
        object IJsonSerializable.ToJson(ExchangeService service)
        {
            JsonObject jsonRequest = new JsonObject();

            jsonRequest.Add(XmlElementNames.MailboxSmtpAddress, this.MailboxSmtpAddress);
            return jsonRequest;
        }

        /// <summary>
        /// Gets the name of the response XML element.
        /// </summary>
        /// <returns>XML element name.</returns>
        internal override string GetResponseXmlElementName()
        {
            return XmlElementNames.GetPasswordExpirationDateResponse;
        }

        /// <summary>
        /// Parses the response.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>Response object.</returns>
        internal override object ParseResponse(EwsServiceXmlReader reader)
        {
            GetPasswordExpirationDateResponse response = new GetPasswordExpirationDateResponse();
            response.LoadFromXml(reader, XmlElementNames.GetPasswordExpirationDateResponse);
            return response;
        }

        /// <summary>
        /// Parses the response.
        /// </summary>
        /// <param name="jsonBody">The json body.</param>
        /// <returns>Response object.</returns>
        internal override object ParseResponse(JsonObject jsonBody)
        {
            GetPasswordExpirationDateResponse serviceResponse = new GetPasswordExpirationDateResponse();
            serviceResponse.LoadFromJson(jsonBody, this.Service);
            return serviceResponse;
        }

        /// <summary>
        /// Gets the request version.
        /// </summary>
        /// <returns>Earliest Exchange version in which this request is supported.</returns>
        internal override ExchangeVersion GetMinimumRequiredServerVersion()
        {
            return ExchangeVersion.Exchange2010_SP1;
        }

        /// <summary>
        /// Executes this request.
        /// </summary>
        /// <returns>Service response.</returns>
        internal GetPasswordExpirationDateResponse Execute()
        {
            GetPasswordExpirationDateResponse serviceResponse = (GetPasswordExpirationDateResponse)this.InternalExecute();
            serviceResponse.ThrowIfNecessary();
            return serviceResponse;
        }

        /// <summary>
        /// Gets or sets the room list to retrieve rooms from.
        /// </summary>
        internal string MailboxSmtpAddress
        {
            get 
            {
                return this.mailboxSmtpAddress;
            }

            set 
            {
                this.mailboxSmtpAddress = value;
            }
        }

        private string mailboxSmtpAddress;
    }
}