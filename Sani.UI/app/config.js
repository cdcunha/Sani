(function () {
    'use strict';

    SETTINGS = { 'SERVICE_URL': 'http://localhost:56914/' };

    angular.module('sani').constant('SETTINGS', SETTINGS);
    
    angular.module('sani').directive('ageLimit', function () {
        return {
            link: function ($scope, $element, $attrs, ngModelCtrl) {
                var settings = {
                    minAge: 16,
                    underAgeMsg: 'A idade mínima é 16 anos.',
                    title: "Informe uma Data de Nascimento válida.",
                    pattern: "^\d{1,2}\/\d{1,2}\/\d{4}$"
                },
                    copyUserSettings = function (attrs, settings) {
                        var property;
                        for (property in settings) {
                            if (settings.hasOwnProperty(property) && attrs.hasOwnProperty(property)) {
                                settings[property] = attrs[property];
                            }
                        }
                    },
                    calculateAge = function (birthday, settings) { // birthday is a string 
                        var regex, today, birthDate, age, month;
                        if (!settings.pattern) {
                            regex = /^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/; //if no pattern provided
                            if (!regex.test(birthday)) {
                                return -1;
                            }
                        }
                        today = new Date();
                        birthDate = new Date(birthday);
                        age = today.getFullYear() - birthDate.getFullYear();
                        month = today.getMonth() - birthDate.getMonth();
                        if (month < 0 || (month === 0 && today.getDate() < birthDate.getDate())) {
                            age = age - 1;
                        }

                        if (isNaN(age)) {
                            return -1;  //if age is invalid
                        }

                        return age;
                    };

                copyUserSettings($attrs, settings);
                $element.on('focusout keydown', function (e) {
                    var age = calculateAge(e.target.value, settings);
                    e.target.setCustomValidity(""); //clear validation               
                    if (-1 === age && settings.title) {
                        e.target.setCustomValidity(settings.title);
                        return;
                    }
                    if (age < parseInt(settings.minAge, 10)) {
                        e.target.setCustomValidity(settings.underAgeMsg);
                    }
                });
            }
        };
    });

})