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
    public interface IVibrationApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IRestResponse ApiVibrationByUseridGet(Guid? userId);
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        IRestResponse ApiVibrationGet();
        /// <summary>
        ///  
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        IRestResponse ApiVibrationPost(AddVibrationRecordDto record);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class VibrationApi : IVibrationApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VibrationApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public VibrationApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VibrationApi"/> class.
        /// </summary>
        /// <returns></returns>
        public VibrationApi(String basePath)
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
        public IRestResponse ApiVibrationByUseridGet(Guid? userId)
        {
            // verify the required parameter 'userId' is set
            if (userId == null) throw new ApiException(400, "Missing required parameter 'userId' when calling ApiVibrationByUseridGet");

            var path = "/api/v1/vibration/{userId}";
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
                throw new ApiException((int)response.StatusCode, "Error calling ApiVibrationByUseridGet: " + response.Content, response.Content);
            if (response.StatusCode == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiVibrationByUseridGet: " + response.ErrorMessage, response.ErrorMessage);

            return response;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>            
        public IRestResponse ApiVibrationGet()
        {

            var path = "/api/v1/vibration";
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
                throw new ApiException((int)response.StatusCode, "Error calling ApiVibrationGet: " + response.Content, response.Content);
            if (response.StatusCode == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiVibrationGet: " + response.ErrorMessage, response.ErrorMessage);

            return response;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="record"></param> 
        /// <returns></returns>            
        public IRestResponse ApiVibrationPost(AddVibrationRecordDto record)
        {
            var path = "/api/v1/vibration";
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
                throw new ApiException((int)response.StatusCode, "Error calling ApiVibrationPost: " + response.Content, response.Content);
            if (response.StatusCode == 0)
                throw new ApiException((int)response.StatusCode, "Error calling ApiVibrationPost: " + response.ErrorMessage, response.ErrorMessage);

            return response;
        }
    }
}
