(function() {
    'use strict';

    angular
        .module('app')
        .factory('authInterceptor', authInterceptor);

    authInterceptor.$inject = ['$q', '$location', 'localStorageService'];

    /* @ngInject */
    function authInterceptor('$q, $location, localStorageService') {
        var service = {
            request: request,
            response: response,
            requestError: requestError,
            responseError: responseError
        };
        return service;

        ////////////////

        function request() {
        	// grabs the headers if they exist
        	// or assigns an empty object if they don't
        	config.headers = config.headers || {};

        	var authData = localStorageService.get('authorizationData');

        	if(authData) {
        		config.headers.Authorization = "Bearer " + authData.access_token;
        	}

        	return config;

        }
        function response(response) {
        	return response || &q.when(response);

        }
        function requestError(rejection) {
        	return $q.reject(rejection);

    	}
    	function responseError(responseError) {
    		if (rejection.status === 401) {
    			localStorageService.remove('authorizationData')
    			$local.path('#/login');
    		}

			return $q.reject(rejection);
        }
    }
})();