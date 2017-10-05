var app = angular.module("hotelModule", ["ngRoute"])
                .config(function ($routeProvider, $locationProvider) {
                  
                    $routeProvider.caseInsensitiveMatch=true;
                  
                    $routeProvider
                        .when("/",
                            {
                                templateUrl: "Templates/home.html",
                                controller: "homeController"
                            })
                        .when("/home",
                            {
                                templateUrl: "Templates/home.html",
                                controller: "homeController"
                            })
                        .when("/hotels",
                            {
                                templateUrl: "Templates/hotels.html",
                                controller: "hotelsController"
                            })
                        .when("/hotels/:id",
                            {
                                templateUrl: "Templates/hotelDetails.html",
                                controller: "hotelDetailsController"
                            })
                        .when("/places",
                            {
                                templateUrl: "Templates/places.html",
                                controller: "placesController"
                            })
                        .when("/travelling",
                            {
                                templateUrl: "Templates/travelling.html",
                                controller: "travellingController"
                            })
                        .otherwise({
                            redirectTo: "/home"
                        });
                    $locationProvider.html5Mode(true);
                })

                .controller("homeController", function ($scope) {
                    $scope.message = "Discovering Ilam";
                })
                .controller("hotelsController", function ($scope, $http) {
                    $http.get("HotelsService.asmx/GetAllHotels")
                        .then(function (response) {
                            $scope.hotels = response.data;

                        });
                })
                .controller("hotelDetailsController", function ($scope, $http, $routeParams) {
                    $http({
                        url: "HotelsService.asmx/GetHotel",
                        params: { id: $routeParams.id },
                        method: "get"
                    })
                        .then(function (response) {
                            $scope.hotel = response.data;
                        });
                })
                .controller("placesController", function ($scope) {
                    $scope.places = ["Kanyam", "Pathivara", "Maipokhari", "Shree Antu", "Sandakpur", "Pashupati Nagar", "Aaitabare"];
                })
                .controller("travellingController", function ($scope) {
                    $scope.info = "How to get here?";
                });
