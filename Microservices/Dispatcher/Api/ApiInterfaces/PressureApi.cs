using System;
using System.Collections.Generic;
using RestSharp;
using Client;
using Model.ApiDtos;

namespace Api.ApiInterfaces
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IPressureApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IRestResponse ApiPressureByUseridGet(Guid? userId);
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        IRestResponse ApiPressureGet();
        /// <summary>
        ///  
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        IRestResponse ApiPressurePost(AddPressureRecordDto record);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class PressureApi : IPressureApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PressureApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public PressureApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PressureApi"/> class.
        /// </summary>
        /// <returns></returns>
        public PressureApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="userId"></param> 
        /// <returns></returns>            
        public IRestResponse ApiPressureByUseridGet(Guid? userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling ApiPressureByUseridGet");

            var path = "/api/v1/pressure/{userId}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{userId}", ApiClient.ParameterToString(userId));

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if ((int)response.StatusCode >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiPressureByUseridGet: " + response.Content, response.Content);
            if (response.StatusCode == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiPressureByUseridGet: " + response.ErrorMessage, response.ErrorMessage);

            return response;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>            
        public IRestResponse ApiPressureGet()
        {

            var path = "/api/v1/pressure";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (RestResponse)ApiClient.CallApi(path, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if ((int)response.StatusCode >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiPressureGet: " + response.Content, response.Content);
            if (response.StatusCode == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiPressureGet: " + response.ErrorMessage, response.ErrorMessage);

            return response;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="record"></param> 
        /// <returns></returns>            
        public IRestResponse ApiPressurePost(AddPressureRecordDto record)
        {
            var path = "/api/v1/pressure";
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(record); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if ((int)response.StatusCode >= 400)
                throw new ApiException((int)response.StatusCode, "Error calling ApiPressurePost: " + response.Content, response.Content);
            if (response.StatusCode == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiPressurePost: " + response.ErrorMessage, response.ErrorMessage);

            return response;
        }
    }
}
