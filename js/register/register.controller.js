(function() {
    'use strict';

    angular
        .module('app')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['	authService','$state', 'toastr'];

    /* @ngInject */
    function RegisterController(dependencies) {authService, $state, toastr) {

        var vm = this;

        vm.register = function() {
        	authService.register(vm.registration)
        				.then(
        					function(response) {
        						toastr.success('Registration succeeded')
        					}
        }


        }
    }
})();