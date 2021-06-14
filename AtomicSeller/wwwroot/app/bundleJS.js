/**
 * Caisse des Congés Payés - Extranet V4
 * Lib utils
 */

window.Utils = {
    /**
     * Updates/adds a parameter in the query string
     * http://stackoverflow.com/questions/5999118/add-or-update-query-string-parameter
     */
    updateQueryString: function(key, value, url) {
        if (!url) url = window.location.href;
        var re = new RegExp("([?&])" + key + "=.*?(&|#|$)(.*)", "gi"),
            hash;

        if (re.test(url)) {
            if (typeof value !== 'undefined' && value !== null)
                return url.replace(re, '$1' + key + "=" + value + '$2$3');
            else {
                hash = url.split('#');
                url = hash[0].replace(re, '$1$3').replace(/(&|\?)$/, '');
                if (typeof hash[1] !== 'undefined' && hash[1] !== null)
                    url += '#' + hash[1];
                return url;
            }
        } else {
            if (typeof value !== 'undefined' && value !== null) {
                var separator = url.indexOf('?') !== -1 ? '&' : '?';
                hash = url.split('#');
                url = hash[0] + separator + key + '=' + value;
                if (typeof hash[1] !== 'undefined' && hash[1] !== null)
                    url += '#' + hash[1];
                return url;
            } else
                return url;
        }
    },

    commaSeparatedValues: function(array) {
        if (array.length === 0)
            return '';

        var t = '';
        for (var i = 0, l = array.length; i < l; i++)
            t += array[i] + ',';

        // Remove trailing comma
        return t.substr(0, t.length - 1);
    },

    extract: function(array, func) {
        var a = [];

        for (var i = 0, l = array.length; i < l; i++)
            a.push(func(array[i]));

        return a;
    },

    parseDate: function(ddmmyyyy) {
        if (ddmmyyyy.length != 'dd/mm/yyyy'.length)
            return null;

        var day = ddmmyyyy.substr(0, 'dd'.length),
            month = ddmmyyyy.substr('dd/'.length, 'mm'.length),
            year = ddmmyyyy.substr('dd/mm/'.length, 'yyyy'.length);

        return new Date(year, month - 1, day);
    },

    addEventHandler: function(array, type, func) {
        for (var i = 0, l = array.length; i < l; i++)
            $(array[i].bind(type, func));
    },

    setIsLoading: function (state) {
        $('body').toggleClass('loading', state);
    }
};

/**
 * Caisse des Congés Payés - Extranet V4
 * Lib forms
 */

window.Forms = {
    initMask: function (element, mask, stripNonNumericCharsOnSubmit) {
        stripNonNumericCharsOnSubmit = typeof stripNonNumericCharsOnSubmit !== 'undefined' ? stripNonNumericCharsOnSubmit : true;
        element.mask(mask);

        if (element.attr('placeholder') === undefined)
            element.attr('placeholder', mask.replace(/\d/g, '_'));

        // On form submit, strip all non-numeric chars from value
        if (stripNonNumericCharsOnSubmit) {
            element.closest('form').submit(function() {
                element.val(element.val().replace(/\D/g, ''));

                return true;
            });
        }
    },

    destroyAutonumeric: function (elem) {
        if (!elem.is('[data-autonumeric]'))
            return;

        var val = elem.val();
        elem.autoNumeric('destroy');
        elem.removeAttr('data-autonumeric');
        //elem.off('.autoNumeric'); fixed in https://github.com/BobKnothe/autoNumeric/issues/234
        elem.val(val);
    },

    getAutoNumericRawFloatValue: function (elem) {
        var replaceWith = {
            ',': '.',
            ' €': '',
            '_': ''
        };

        var val = elem.val();

        for (var replace in replaceWith) {
            if (replaceWith.hasOwnProperty(replace))
                val = val.replaceAll(replace, replaceWith[replace]);
        }

        if (val === '' || val === '.')
            return 0;

        return parseFloat(val);
    },

    fieldValidationError: function (fieldElem, message, isError) {
        isError = isError === undefined ? true : isError;

        var fieldValidation = fieldElem.parent().find('span[class*="field-validation"]'),
            isOk = !(message != null && message.length > 0);

        if (!isOk) {
            fieldValidation
                .removeClass('field-validation-valid')
                .addClass('field-validation-error')
                .text(message);

            if (isError)
                fieldElem[0].setCustomValidity('Erreur');
        } else {
            fieldValidation
                .addClass('field-validation-valid')
                .removeClass('field-validation-error')
                .text('');

            if (isError)
                fieldElem[0].setCustomValidity('');
        }

        fieldElem.closest('.form-group').toggleClass('has-error', !isOk);
    },

    /**
     * Adds a bootstrap input-group-addon
     * without losing events attached to fieldElem
     * @param {} fieldElem 
     * @param {} text 
     * @returns {} 
     */
    appendInputGroupAddon: function (fieldElem, text) {
        var parent = fieldElem.parent();

        return $('<div />')
            .addClass('input-group')
            .append(fieldElem.detach())
            .append(
                $('<span />')
                    .addClass('input-group-addon')
                    .text(text)
            )
            .appendTo(parent);
    }
};

/**
 * Caisse des Congés Payés - Extranet V4
 * Lib metier
 */

window.Metier = {
    getNumSSRawValue: function (elem) {
        return elem.val()
            .replaceAll('.', '')
            .replaceAll('/', '')
            .replaceAll('_', '');
    },

    getCleNumSS: function (numSS) {
        numSS = numSS.toLowerCase();
        var bMatricule = false;

        for (var i = 0, l = numSS.length; i < l; i++) {
            var letter = numSS[i];
            if (letter <= 'z' && letter >= 'c')
                bMatricule = true;
        }

        if (bMatricule)
            return '99';

        var _numSS = numSS.substr(0, 13),
            _presenceA = _numSS.indexOf('a') > -1,
            _presenceB = _numSS.indexOf('b') > -1;

        _numSS = _numSS
            .replaceAll('a', '0')
            .replaceAll('b', '0');

        var n = parseInt(_numSS);

        if (isNaN(n))
            return null;

        if (_presenceA)
            n -= 1000000;
        if (_presenceB)
            n -= 2000000;

        var cleSS = (97 - (n % 97)).toString();
        return cleSS.length == 1
            ? '0' + cleSS
            : cleSS;
    },

    getDateNaissance: function (numSS, numCaisse) {
        var result = {
            dateNaissance: null,
            dateNaissanceInconnue: null
        };

        var now = new Date();
        now.setFullYear(now.getUTCFullYear() - 16);

        var year = now.getFullYear(),
            iYear = parseInt(numSS.substr(1, 2));
        if (!isNaN(iYear))
            year = iYear;

        if (year < 30)
            year += 2000;
        else
            year += 1900;

        var month = now.getMonth() + 1,
            iMonth = parseInt(numSS.substr(3, 2));
        if (!isNaN(iMonth))
            month = iMonth;

        if (numCaisse == 34 || month > 0 && month <= 12 || numSS.substr(0, 13) == '0000000000000')
            result.dateNaissance = new Date(year, month - 1, 1);
        else
            result.dateNaissanceInconnue = year;

        return result;
    },

    getCodifTitre: function(titre) {
        switch (titre) {
            case 1:
                return ['010'];
            case 2:
                return ['020', '030'];
            default :
                return null;
        }
    },

    getTitreFromNumSS: function(numSS) {
        if (numSS.length == 0)
            return null;

        var s = parseInt(numSS.substr(0, 1));
        return s === 1 || s === 2 ? s : null;
    }
};

/**
 * Caisse des Congés Payés - Extranet V4
 * Composant Javascript - Confirm
 */

(function ($, window) {
    var Confirm = function(elem, options) {
        this.elem = elem;
        this.options = options;
    };

    Confirm.prototype = {
        defaults: {
            message: null,
            action: null
        },

        init: function () {
            var self = this;
            this.settings = $.extend({}, this.defaults, this.options);
            
            this.settings.message = this.settings.message || this.elem.data('message');
            this.settings.action = this.settings.action || this.elem.data('action') || this.elem.attr('href');

            this.elem.attr('href', '#');
            this.dialog = $('#confirmModal');

            this.elem.click(function(e) {
                e.preventDefault();

                self.showConfirmDialog();
            });
        },

        showConfirmDialog: function () {
            this.dialog.find('.modal-body-content').find('span').text(this.settings.message);
            this.dialog.find('.modal-confirm-button').attr('href', this.settings.action);
            this.dialog.modal('show');
        },

        closeConfirmDialog: function() {
            this.dialog.modal('hide');
        }
    };


    Confirm.defaults = Confirm.prototype.defaults;

    $.fn.confirm = function (options) {
        this.each(function() {
            new Confirm($(this), options).init();
        });
    };

    window.Confirm = Confirm;
}(jQuery, window));

/**
 * Caisse des Congés Payés - Extranet V4
 * Composant Javascript - Drawer (menu latéral)
 */

(function ($, window) {
    var Drawer = function(elem, options) {
        this.elem = $(elem);
        this.options = options;
    };

    Drawer.prototype = {
        defaults: {
        },

        init: function () {
            var self = this;
            this.settings = $.extend({}, this.defaults, this.options);

            this.menuItems = this.elem.find('.menu-item');
            this.menuSubItems = this.menuItems.find('a');
            
            // Update active item on click
            this.menuSubItems.click(function () {
                menuSubItems.removeClass('active');
                $(this).addClass('active');
            });

            // Toggle submenus visibility on parent click
            this.menuItems.click(function (e) {
                if ($(this).is('.disabled'))
                    return;

                // If that's a footer link, just open it
                if (!$(this).is('a[href="#"]'))
                    return;

                e.preventDefault();
                var openedMenuItem = self.menuItems.filter('.open');

                // Close currently open menuItem
                self.toggleItem(openedMenuItem);

                if (!openedMenuItem.is($(this)))
                    self.toggleItem($(this));
            });

            // Responsive mode: toggle
            var body = $('body');
            var navMask = $('.nav-fullmask').click(function () {
                body.removeClass('nav-shown')
                    .addClass('nav-hidden');
                navMask.fadeOut(300);
            });
            $('header').find('.toggle-menu').click(function (e) {
                e.preventDefault();

                var isMobile = window.matchMedia('only screen and (max-width: 767px)').matches;
                
                // First click
                if (!body.is('.nav-shown') && !body.is('.nav-hidden'))
                    body.addClass(isMobile ? 'nav-shown' : 'nav-hidden');
                else {
                    body.toggleClass('nav-shown')
                        .toggleClass('nav-hidden');
                }

                if (isMobile)
                    navMask.fadeIn(300);
            });
        },

        /**
         * Toggles visibility for this menu element's child items
         */
        toggleItem: function(menuItem) {
            menuItem
                .toggleClass('open');

            menuItem.closest('li').find('ul').slideToggle(200);
        }
    };


    Drawer.defaults = Drawer.prototype.defaults;

    $.fn.drawer = function(options) {
        return new Drawer(this.first(), options).init();
    };

    window.Drawer = Drawer;
}(jQuery, window));

/**
 * Form Dynamism
 * Usage:
 * 
 * $('#elem-to-be-hidden').visibilityCondition({params})
 * 
 * Modes:
 *  - Condition (function)
 *  {
 *      condition: function(elem, trigger) {
 *          // Some complicated code
 *          return true; // <- return true or false
 *      }
 *  }
 * 
 *  - Condition (value)
 *  {
 *      condition: '010' // elem will be shown if trigger.val() == '010'
 *  }
 * 
 *  - Condition (array)
 *  {
 *      condition: ['010', '020', '030'] // elem will be shown if its value matches one of this item elements
 *  }
 * 
 */
(function ($, window) {
    /**
     * @param {} elem Element to be shown/hidden
     * @param {} options 
     * @returns {} 
     */
    var VisibilityCondition = function(elem, options) {
        this.elem = $(elem);
        this.options = options;
    };

    VisibilityCondition.prototype = {
        defaults: {
            condition: null,
            /**
             * When this element's value changes, condition is called
             */
            trigger: null,
            /**
             * When this event is fired on the trigger, condition is called
             */
            event: 'change',
            /**
             * Will use toggle if false
             */
            animate: true
        },

        init: function() {
            var self = this;
            this.settings = $.extend({}, this.defaults, this.options);

            // Bind event
            var event = this.settings.event;
            this.settings.trigger.on(event, function () {
                self.updateVisibility();
            });

            // Update visibility
            this.updateVisibility();
        },

        updateVisibility: function () {
            var result = false;
            var triggerVal = this.settings.trigger.val();

            if (typeof this.settings.condition === "string") { // Singlevalue
                result = triggerVal === this.settings.condition;
            } else if (typeof this.settings.condition === "object") { // Array
                result = this.settings.condition.indexOf(triggerVal) !== -1;
            } else if (typeof this.settings.condition === "function") { // Function
                result = this.settings.condition(this.elem, this.settings.trigger);
            }

            if (result !== true && result !== false)
                return;

            if (this.settings.animate)
                this.elem.fadeInOrOut(result);
            else
                this.elem.toggle(result);
        }
    };

    VisibilityCondition.defaults = VisibilityCondition.prototype.defaults;

    $.fn.visibilityCondition = function(options) {
        return new VisibilityCondition(this, options).init();
    }

    window.VisibilityCondition = VisibilityCondition;
}(jQuery, window));

/**
 * Password strength component
 * 
 * Usage:

<hr/>
<div class="col-sm-8 col-sm-offset-4">
    <div id="password-alert" class="alert"></div>
</div>
@Html.EditorFor(m => m.Password)
@Html.EditorFor(m => m.PasswordBis)

<script>
    $(document).ready(function() {
        $('#Password').passwordStrength({
            bisElem: $('#PasswordBis'),
            alert: $('#password-alert')
        });
    });
</script>

 */
(function ($, window) {
    var StrengthLevel = {
        WEAK: 'weak',
        MEDIUM: 'medium',
        STRONG: 'strong'
    };

    var PasswordStrength = function(elem, options) {
        this.elem = $(elem);
        this.options = options;
    };

    PasswordStrength.prototype = {
        defaults: {
            bisElem: null,
            alert: null,
            submitButton: null,
            inputGroupAddons: null,

            rules: {
                minStrength: StrengthLevel.MEDIUM,
                minLength: 8,
                atLeastOneDigit: true,
                atLeastOneLetter: true,
                atLeastOneUppercaseLetter: false,
                atLeastOneSpecialChar: false
            }
        },

        init: function () {
            var self = this;
            this.settings = $.extend({}, this.defaults, this.options);

            if (this.settings.submitButton == null)
                this.settings.submitButton = this.elem.closest('form').find('[type="submit"]');

            this.elem.add(this.settings.bisElem)
                .on('keyup change', function() {
                    self.testStrengthLive();
                })
                .trigger('keyup');
        },

        testStrengthLive: function () {
            var self = this;
            var strengthArray = this.getStrength(this.elem.val(), this.settings.bisElem.val()),
                strength = strengthArray[0],
                strengthMessage = strengthArray[1],
                strengthColor = this.getStrengthColor(strength);

            this.elem.add(this.settings.bisElem).css('border-color', strengthColor);
            this.settings.alert[0].classList = 'alert alert-' + this.getAlertClass(strength);
            this.settings.alert
                .toggle(strengthMessage != null)
                .text(strengthMessage);
            
            if (strength === StrengthLevel.WEAK)
                this.settings.submitButton.attr('disabled', 'disabled');
            else
                this.settings.submitButton.removeAttr('disabled');

            this.elem.add(this.settings.bisElem).each(function() {
                $(this)
                    .parent()
                    .find('.input-group-addon')
                    .html(self.getInputGroupAddonContent(strength))
                    [0].classList = 'input-group-addon bg-' + self.getAlertClass(strength);
            });
        },

        getStrengthColor: function(strength) {
            return {
                'weak': '#D50000',
                'medium': '#0277BD',
                'strong': '#2E7D32'
            }[strength];
        },

        getAlertClass: function(strength) {
            return {
                'weak': 'danger',
                'medium': 'info',
                'strong': 'success'
            }[strength];
        },

        getInputGroupAddonContent: function(strength) {
            return {
                'weak': '<i class="mdi mdi-emoticon-sad"></i>',
                'medium': '<i class="mdi mdi-emoticon-happy"></i>',
                'strong': '<i class="mdi mdi-emoticon"></i>'
            }[strength];
        },

        getStrength: function (password, password2) {
            if (password.length === 0)
                return [StrengthLevel.WEAK, null];

            if (password.length < this.settings.rules.minLength)
                return [StrengthLevel.WEAK, 'Le mot de passe doit contenir au moins ' + this.settings.rules.minLength + ' caractères'];

            // Check if it contains numbers
            if (this.settings.rules.atLeastOneDigit) {
                if (!/\d/.test(password))
                    return [StrengthLevel.WEAK, 'Le mot de passe doit contenir au moins un chiffre'];
            }

            // Check if it contains letters
            if (this.settings.rules.atLeastOneLetter) {
                if (!/[a-zA-Z]/.test(password))
                    return [StrengthLevel.WEAK, 'Le mot de passe doit contenir au moins une lettre.'];
            }

            if (password !== password2 && password.length > 0)
                return [StrengthLevel.WEAK, 'Vous avez saisi deux mots de passe différents'];

            var level = StrengthLevel.MEDIUM;

            // Check if it contains uppercase letters
            var mustHaveUppercaseLetter = this.settings.rules.atLeastOneUppercaseLetter;
            var hasUppercaseLetter = /[A-Z]/.test(password);
            if (mustHaveUppercaseLetter && !hasUppercaseLetter)
                return [StrengthLevel.WEAK, 'Le mot de passe doit contenir au moins une majuscule.'];
            else if (!mustHaveUppercaseLetter && hasUppercaseLetter)
                level = StrengthLevel.MEDIUM;

            
            // Check if it contains special chars
            var mustHaveSpecialChar = this.settings.rules.atLeastOneSpecialChar;
            var hasSpecialChar = /[$-/:-?{-~!"^_`\[\]]/.test(password);
            if (mustHaveSpecialChar && !hasSpecialChar)
                return [StrengthLevel.WEAK, 'Le mot de passe doit contenir au moins un caractère spécial.'];
            else if (!mustHaveSpecialChar && hasSpecialChar)
                level = StrengthLevel.STRONG;
            
            // Check if its length is long enough to be strong
            if (password.length > 12)
                return [StrengthLevel.STRONG, null];

            return [level, null];
        }
    };

    PasswordStrength.defaults = PasswordStrength.prototype.defaults;

    $.fn.passwordStrength = function(options) {
        return new PasswordStrength(this, options).init();
    }

    window.PasswordStrength = PasswordStrength;
}(jQuery, window));

/**
 * Caisse des Congés Payés - Extranet V4
 * Visite guidée
 * 
 * Steps are defined in _VisiteGuidee.cshtml
 */

(function() {
    var joyride,
        joyrideOptions,
        wizard,
        isRiding = false;

    var beginTour = function(wizard, joyrideOptions, forceStart) {
        // Destroy previous instance
        wizard.joyride('destroy');

        joyrideOptions.cookieMonster = !forceStart;

        joyride = wizard.joyride(joyrideOptions);
    };
    var appendHelpIconToHeader = function () {
        // Already added, abort
        if ($('.joyride-starter').length !== 0)
            return;

        // Add "help" action button to header
        $('<a />')
            .attr('href', '#')
            .attr('data-toggle', 'tooltip')
            .attr('data-placement', 'left')
            .attr('title', 'Aide')
            .addClass('action joyride-starter')
            .append(
                $('<i />')
                    .addClass('mdi mdi-help-circle')
            )
            .click(function () {
                beginTour(wizard, joyrideOptions, true);
            })
            .prependTo($('.header-right').find('.actions').first());
    };

    $(document).ready(function() {
        var visiteGuidee = $('body').data('visite-guidee');

        // There's no wizard for this page, skip
        if (visiteGuidee === undefined)
            return;

        // Find the right wizard from _VisiteGuidee.cshtml
        wizard = $('ol[data-visite-guidee="' + visiteGuidee + '"]');

        if (wizard.length !== 1) {
            console.error('Could not find the right wizard, aborting');
            return;
        }

        // Bind close event to not proceed
        $('body').on('click', '.joyride-close-tip', function () {
            isRiding = false;
        });

        // These are shared parameters from each joyride wizard
        var baseJoyrideOptions = {
            autoStart: true,
            cookieName: 'VisiteGuidee',
            modal: true,
            preRideCallback: function() {
                isRiding = true;
            },
            postRideCallback: function() {
                isRiding = false;
                appendHelpIconToHeader();
            }
        };
        var specificJoyrideOptions = {};

        // Here, we define parameters for each joyride wizard
        switch (visiteGuidee) {
            case 'profil':
                specificJoyrideOptions = {
                    pauseAfter: [3],
                    postStepCallback: function (index, tip) {
                        // Don't execute callback if ride is stopped
                        if (!isRiding)
                            return;

                        // Trigger some events depending on index
                        switch (index) {
                            case 3:
                                // Open and close some menu sections
                                var menuItems = $('nav > ul > li > a.menu-item[href="#"]').toArray();

                                var clickAndWait = function () {
                                    var menuItem = menuItems.shift();
                                    menuItem.click();

                                    if (menuItems.length > 0)
                                        setTimeout(clickAndWait, 500); // <- adjust delay here
                                    else
                                        joyride.joyride('resume');
                                };

                                clickAndWait();
                        }
                    }
                };
                break;
        }

        joyrideOptions = $.extend({}, baseJoyrideOptions, specificJoyrideOptions);

        // Init joyride once window will have finished loading
        $(window).load(function () {
            beginTour(wizard, joyrideOptions, false);

            if (!isRiding) // Tour hasn't started (cookie)
                appendHelpIconToHeader();
        });
    });
})();

// Replace all occurences
String.prototype.replaceAll = function (search, replacement) {
    var target = this;
    return target.split(search).join(replacement);
};

Date.prototype.toShortDateString = function () {
    var date = this.getDate(),
        month = this.getMonth() + 1,
        year = this.getFullYear();

    return (date <= 9 ? '0' + date : date) + '/' +
        (month <= 9 ? '0' + month : month) + '/' +
        year;
}

// Default datepicker language
$.extend($.fn.datepicker.defaults,
{
    language: 'globalize',
    weekStart: 1,
    format: 'dd/mm/yyyy',
    todayBtn: false,
    todayHighlight: true
});

// AutoNumeric
$.extend($.fn.autoNumeric.defaults,
{
    aSep: ' ',
    aDec: ',',
    altDec: '.',
    pSign: 's'
});

// Mask
$.mask.autoclear = false;

$.fn.fadeInOrOut = function (status) {
    return status ? this.fadeIn() : this.fadeOut();
}

$(document).ready(function () {
    if (!$('body').is('.page-login')) {
        // Menu latéral
        $('nav').drawer();

        // Tablesorters
        $('.table:not(.sorter-false)').each(function() {
            var options = {
                dateFormat: 'uk',
                sortReset: true
            };

            if ($(this).is('.filter-true')) {
                var table = $(this);

                // Add filter button to panel
                if (!!$(this).closest('.panel').length) {
                    $('<i />')
                        .attr('data-toggle', 'tooltip')
                        .attr('data-placement', 'left')
                        .attr('title', 'Filtrer')
                        .addClass('mdi mdi-filter pull-right')
                        .click(function () {
                            $(this)
                                .toggleClass('mdi-filter')
                                .toggleClass('mdi-filter-outline');

                            table.find('.tablesorter-filter-row').toggle();
                            table.find('.input-sm:first').focus();
                        })
                        .appendTo($(this).closest('.panel').find('.panel-heading'));
                }

                options = $.extend(options, {
                    widthFixed: true,
                    cssChildRow: "tablesorter-childRow",
                    widgets: ['filter'],
                    widgetOptions: {
                        filter_cssFilter: 'form-control input-sm',
                        filter_placeholder: { search: 'Filtrer…', select: '' },
                        filter_childRows: false
                    }
                });
            }

            $(this).tablesorter(options);
        });
        $('.table:not(.sorter-false)').tablesorter({
            dateFormat: 'uk',
            sortReset: true
        });

        // AutoNumeric
        $('[data-autonumeric]').each(function (i, elem) {
            var options = {};

            if ($(this).is('[data-type="Currency"]'))
                options.aSign = ' €';

            $(elem).autoNumeric('init', options);
        });
    }
    
    // Callouts
    $('.bs-close').click(function() {
        $(this).closest('.bs-callout').slideUp();
    });

    // Init file pickers
    $(':file').on('fileselect', function (event, numFiles, label) {
        var input = $(this).parents('.input-group').find(':text'),
            log = numFiles > 1 ? numFiles + ' fichiers sélectionnés' : label;

        if (input.length)
            input.val(log);
    });

    // Datepickers
    $('.datepicker').each(function() {
        var minDate = $(this).data('date-min'),
            maxDate = $(this).data('date-max');

        var options = {
            language: 'fr',
            enableOnReadonly: false
        };

        if (minDate !== "")
            options['startDate'] = new Date(minDate);
        if (maxDate !== "")
            options['endDate'] = new Date(maxDate);

        $(this).datepicker(options);

        $('<i/>').addClass('mdi mdi-calendar').insertAfter($(this));
    });
    
    // Confirmations
    $('.confirmation[data-message]').confirm();

    // Handle form submitting for AutoNumeric
    $('form').submit(function () {
        $('input').each(function() {
            var self = $(this);

            try {
                var v = self.autoNumeric('get');
                self.autoNumeric('destroy');

                // Update format (dd.dd => dd,dd)
                v = v.replaceAll('.', ',');

                self.val(v);
            } catch(err) {
                // Not an autonumeric field
            }
        });

        return true;
    });

    // Tooltips
    $('[data-toggle="tooltip"]').tooltip({
        container: 'body',
        animation: false
    });

    // Togglable panels
    $('.panel-togglable').find('.panel-heading').click(function() {
        $(this)
            .parent().toggleClass('panel-togglable-closed')
            .children().filter(':not(.panel-heading)').slideToggle();
    });
    $('.panel-closed').find('.panel-heading').click();

    // Pagination: init links
    $('.pagination-wrap').find('[data-page]').each(function() {
        $(this).attr('href', Utils.updateQueryString('page', $(this).data('page')));
    });

    // Mask on datepickers
    Forms.initMask($('input.datepicker'), '99/99/9999', false);

    $('.forceStopLoading').click(function () {
        setTimeout(function () { Utils.setIsLoading(false); }, 2000);
    });

    $('.filterable').find('.mdi-filter').click();
});

// Display loading animation on page unload...
window.onbeforeunload = function () {
    Utils.setIsLoading(true);
};
// ... and on every ajax request
$.ajaxSetup({
    beforeSend: function() {
        Utils.setIsLoading(true);
    },
    complete: function() {
        Utils.setIsLoading(false);
    }
});
