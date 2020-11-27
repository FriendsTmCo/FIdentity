/*[PATH @convert.date.js]*/
function div(r, t) { return parseInt(r / t) } function gregorian_to_jalali(r, t, e) { for (var n = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31], u = [31, 31, 31, 31, 31, 31, 30, 30, 30, 30, 30, 29], s = [], a = r - 1600, c = t - 1, i = e - 1, o = 365 * a + div(a + 3, 4) - div(a + 99, 100) + div(a + 399, 400), _ = 0; _ < c; ++_) o += n[_]; c > 1 && (a % 4 == 0 && a % 100 != 0 || a % 400 == 0) && o++; var v = (o += i) - 79, d = 979 + 33 * div(v, 12053) + 4 * div(v %= 12053, 1461); (v %= 1461) >= 366 && (d += div(v - 1, 365), v = (v - 1) % 365); for (_ = 0; _ < 11 && v >= u[_]; ++_) v -= u[_]; var b = _ + 1, f = v + 1; return s[0] = d, s[1] = b, s[2] = f, s } function get_year_month_day(r) { return gregorian_to_jalali(r.substr(0, 4), r.substr(5, 2), r.substr(8, 2)) } function get_hour_minute_second(r) { var t = []; return t[0] = r.substr(0, 2), t[1] = r.substr(3, 2), t[2] = r.substr(6, 2), t } function convertDate(r) { var t = get_year_month_day(r.substr(0, 10)); return t = t[0] + "/" + t[1] + "/" + t[2] + " " + r.substr(10) } function get_persian_month(r) { switch (r) { case 1: return "فروردین"; case 2: return "اردیبهشت"; case 3: return "خرداد"; case 4: return "تیر"; case 5: return "مرداد"; case 6: return "شهریور"; case 7: return "مهر"; case 8: return "آبان"; case 9: return "آذر"; case 10: return "دی"; case 11: return "بهمن"; case 12: return "اسفند" } }

var Services = {
    gregorianToHijriSlashed: function (date) {
        var convertDateTime = get_year_month_day(date.substr(0, 10));
        var monthVal = parseInt(convertDateTime[1]) < 10 ? "0" + convertDateTime[1] : convertDateTime[1];
        var dayVal = parseInt(convertDateTime[2]) < 10 ? "0" + convertDateTime[2] : convertDateTime[2];
        convertDateTime = convertDateTime[0] + "/" + monthVal + "/" + dayVal + " " + date.substr(10);
        return convertDateTime;
    },
    convertToFaDigit: function (a) {
        var b = '' + a;
        for (var c = 48; c <= 57; c++) {
            var d = String.fromCharCode(c);
            var e = String.fromCharCode(c + 1728);
            b = b.replace(new RegExp(d.toString(), "g"), e.toString())
        }
        return b;
    },
    autoSeparateValue: function (a) {
        var b, c, d, g;
        var e, f;
        b = a;
        b = b.replace(/,/g, "");
        if (b != "") c = b.charAt(0);
        if (c != "-") c = "";
        else b = b.replace(/-/g, "");
        if (b.indexOf(".") == -1) {
            if (b.length > 3) {
                d = "";
                while (b.length > 3) {
                    g = b.substr(0, b.length - 3);
                    var h = b.substr(b.length - 3);
                    var i = "," + h;
                    d = i + d;
                    b = b.substr(0, b.length - 3)
                }
                d = c + g + d
            } else d = c + b
        } else {
            e = b.substring(0, b.indexOf("."));
            f = b.substring(b.indexOf("."));
            if (e.length > 3) {
                d = "";
                while (e.length > 3) {
                    g = e.substr(0, e.length - 3);
                    h = e.substr(e.length - 3);
                    i = "," + h;
                    d = i + d;
                    e = e.substr(0, e.length - 3)
                }
                if (f != ".00") {
                    d = c + g + d + f
                } else d = c + g + d
            } else if (f != ".00") {
                d = c + e + f
            } else d = c + e
        }
        return d
    },
    formatCurrency: function (num, isRial, symbol) {
        num = num.toString().replace(/\$|\,/g, "");
        if (isNaN(num)) num = "0";
        var sign = (num == (num = Math.abs(num)));
        num = Math.round(num * 100 + 0.50000000001);
        num = Math.round(num / (isRial ? 1000 : 100)).toString();
        for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
            num = num.substring(0, num.length - (4 * i + 3)) + ',' + num.substring(num.length - (4 * i + 3));
        return (((sign) ? "" : "-") + num + " " + symbol);
    },
    convertToEnDigit: function (str) {
        return str
            .replace(/۰/g, '0')
            .replace(/۱/g, '1')
            .replace(/۲/g, '2')
            .replace(/۳/g, '3')
            .replace(/۴/g, '4')
            .replace(/۵/g, '5')
            .replace(/۶/g, '6')
            .replace(/۷/g, '7')
            .replace(/۸/g, '8')
            .replace(/۹/g, '9')
            .replace(/٠/g, '0')
            .replace(/١/g, '1')
            .replace(/٢/g, '2')
            .replace(/٣/g, '3')
            .replace(/٤/g, '4')
            .replace(/٥/g, '5')
            .replace(/٦/g, '6')
            .replace(/٧/g, '7')
            .replace(/٨/g, '8')
            .replace(/٩/g, '9');

    },
    setCookie: function (cookieName, cookieValue, expireDays) {
        var d = new Date();
        d.setTime(d.getTime() + (expireDays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        document.cookie = cookieName + "=" + cookieValue + ";" + expires + ";path=/";
    },
    getCookie: function getCookie(cookieName) {
        var name = cookieName + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) === ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) === 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    },
    checkCookie: function (cookieName) {
        var name = this.getCookie(cookieName);
        if (name !== "") {
            return true;
        } else {
            return false;
        }
    },
    windowShow: function (params) {
        // Default settings:
        var settings = {
            title: 'Window',
            message: '',
            animate: true,
            large: false,
            small: false,
            closeable: true,
            buttons: [],
            onAppear: function () { },
            onDisappear: function () { }
        };
        $.extend(settings, params);

        // Close button template:
        var closeButton = [
            '<button type="button"',
            ' class="close" data-dismiss="modal" aria-label="Close">',
            '  <span aria-hidden="true">&times;</span>',
            '</button>'
        ].join('');
        if (!settings.closeable) closeButton = '';

        // Main template:
        var template = [
            '<div class="modal' + (settings.animate ? ' fade effect-scale' : '') + '"',
            ' tabindex="-1" role="dialog">',
            '  <div class="modal-dialog modal-dialog-centered',
            (settings.large ? ' modal-lg' : '') + (settings.small ? ' modal-sm' : ''),
            '" role="document">',
            '   <div class="modal-content">',
            '     <div class="modal-header">',
            '       <h5 class="modal-title">' + settings.title + '</h5>',
            closeButton,
            '     </div>',
            '     <div class="modal-body">' + settings.message + '</div>',
            '   </div>',
            ' </div>',
            '</div>'
        ].join('');

        var element = $(template);

        // Callback parameters:
        var cbParams = {
            element: element,
            close: function () {
                $(element).modal('hide');
            }
        };

        function createButton(footer, btn) {
            var template = [
                '<button class="btn',
                (btn.className ? ' ' + btn.className : ' btn-secondary'),
                '">' + btn.label + '</button>'
            ].join('');

            var btnInstance = $(template);

            if (btn.action) {
                $(btnInstance).click(function () {
                    btn.action(cbParams);
                });
            }

            $(footer).append(btnInstance);
        } // createButton();

        // Adding buttons:
        if (settings.buttons.length > 0) {
            var footer = $('<div class="modal-footer"></div>');

            for (var i = 0; i < settings.buttons.length; i++) {
                createButton(footer, settings.buttons[i]);
            }

            $(element).find('.modal-content:eq(0)').append(footer);
        }

        // Hanging events:
        $(element).on('shown.bs.modal', function (e) {
            settings.onAppear(cbParams);
        });
        $(element).on('hidden.bs.modal', function (e) {
            settings.onDisappear(cbParams);

            $(this).modal('dispose');
            $(this).remove();
        });

        // Finally, show modal:
        if (settings.closeable) {
            $(element).modal();
            return;
        }

        // If not closeable:
        $(element).modal({
            backdrop: 'static',
            keyboard: false
        });
    },
    windowAlert: function (text, title, cb) {
        this.windowShow({
            message: text,
            title: (title ? title : 'Message'),
            buttons: [
                {
                    label: 'Confirm',
                    className: 'btn-primary',
                    action: function (instance) {
                        instance.close();
                    }
                }
            ],
            onDisappear: (cb ? cb : function () { })
        });
    },
    windowConfirm: function (text, title, cb) {
        this.windowShow({
            message: text,
            title: (title ? title : 'Confirm'),
            closeable: false,
            buttons: [
                {
                    label: 'Confirm',
                    className: 'btn-primary',
                    action: function (instance) {
                        instance.close();
                        cb(true);
                    }
                },
                {
                    label: 'Cancel',
                    className: 'btn-danger',
                    action: function (instance) {
                        instance.close();
                        cb(false);
                    }
                }
            ]
        });
    },
    windowPrompt: function (text, value, title, cb) {
        this.windowShow({
            message: [
                '<p>' + text + '</p>',
                '<input type="text" class="form-control bsWindowInput"',
                ' value="' + value + '" />'
            ].join(''),
            title: (title ? title : 'Prompt'),
            closeable: false,
            buttons: [
                {
                    label: 'Confirm',
                    className: 'btn-primary',
                    action: function (instance) {
                        var val = $(instance.element).find('.bsWindowInput:eq(0)').val();
                        instance.close();
                        cb(val);
                    }
                },
                {
                    label: 'Cancel',
                    action: function (instance) {
                        instance.close();
                        cb(null);
                    }
                }
            ]
        });
    },
    message: function (title, message, classname, hasTimer = true) {
        //Swal.fire({
        //    title: title,
        //    text: message,
        //    icon: classname,
        //    timer: hasTimer ? 3000 : undefined,
        //    timerProgressBar: hasTimer ? true : false,
        //    showConfirmButton: hasTimer ? false : true,
        //    allowOutsideClick: hasTimer ? true : false,
        //    allowEscapeKey: hasTimer ? true : false,
        //    confirmButtonText: 'Ok'
        //}).then((result) => {
        //    if (result.value) {
        //        window.location.reload();
        //    }
        //})
        Swal.fire({
            title: title,
            text: message,
            type: classname,
            timer: hasTimer ? 3000 : undefined,
            timerProgressBar: hasTimer ? true : false,
            showConfirmButton: hasTimer ? false : true,
            allowOutsideClick: hasTimer ? true : false,
            allowEscapeKey: hasTimer ? true : false,
            confirmButtonClass: 'btn btn-primary',
            confirmButtonText: 'باشه',
            buttonsStyling: false,
        });
    },
    loading: function (display) {
        if (display) {
            $.blockUI({ message: '<div class="bx bx-reset icon-spin font-large-2"></div>', overlayCSS: { backgroundColor: '#fff', opacity: 0.8, cursor: 'wait' }, css: { border: 0, padding: 0, backgroundColor: 'transparent' } });
        }
        else {
            $.unblockUI();
        }
    },
    scrollWindowTop: function (el) {
        if (el != undefined)
            $('html, body').animate({ scrollTop: $(el).offset().top }, 700);
        else
            $('html, body').animate({ scrollTop: 0 }, 700);
    },
    postJSON: function (url, data, success, error, antiForgeryToken, dataType, resposeType) {
        if (dataType === void 0) { dataType = "json"; }
        if (typeof (data) === "object") { data = JSON.stringify(data); }
        var ajax = {
            url: url,
            type: dataType,
            contentType: "application/json; charset=utf-8",
            dataType: resposeType,
            data: data,
            success: success,
            error: error
        };
        if (antiForgeryToken) {
            ajax.headers = {
                "__RequestVerificationToken": antiForgeryToken
            };
        };

        return $.ajax(ajax);
    },
    postFormData: function (url, data, success, error, antiForgeryToken) {
        var ajax = {
            url: url,
            type: "Post",
            data: data,
            cache: false,
            contentType: false,
            processData: false,
            success: success,
            error: error
        };
        if (antiForgeryToken) {
            ajax.headers = {
                "__RequestVerificationToken": antiForgeryToken
            };
        };

        return $.ajax(ajax);
    }
};

var MainForm = {
    init: function () {
        var functions = [
            this.initMain
        ];
        var self = this;
        $(functions).map(function (index, item) {
            item = item.bind(self);
            try {
                item();
            } catch (e) {
                console.log("Error: ", e);
            }
        });
    },
    initMain: function () {
        $('select').select2({}).on("change", function (e) {
            $(this).valid()
        });

        $.validator.addMethod(
            "select-is-required",
            function (value, element) {
                console.log(element.value)
                if (element.value === "0" ||
                    element.value === null ||
                    element.value === "" ||
                    element.value === undefined) { return false; }
                else return true;
            },
            "موردی انتخاب نشده است"
        );
    },
    initPersonEdit: function () {
        $("#drpState").on('change', function () {
            var StateId = $(this).val();
            var url = "/Person/FillCity?StateId=" + StateId;
            Services.postJSON(url, null, function success(data) {
                console.log(data)
                var drpCity = $("#drpCity");
                drpCity.empty();
                drpCity.append($('<option/>', {
                    value: 0,
                    text: "-- انتخاب کنید --"
                }));
                $.each(data, function (index, itemData) {
                    drpCity.append($('<option/>', {
                        value: itemData.value,
                        text: itemData.text
                    }));
                });
            }, function error(data) {
            }, "GET", "HTML");
        });
        $("#PersonTypeId").on('change', function () {
            var PersonTypeId = $(this).val();
            var ServicesTypePanel = $("#pnlServicesType");
            if (PersonTypeId == "3" || PersonTypeId == "4")
                ServicesTypePanel.slideDown("slow");
            else {
                $("input[type=checkbox][name=PersonServiceIds]").prop("checked", false);
                ServicesTypePanel.slideUp("slow");
            }
        });
    },
    initServiceCenterEdit: function () {
        $("#drpState").on('change', function () {
            var StateId = $(this).val();
            var url = "/ServiceCenter/FillCity?StateId=" + StateId;
            Services.postJSON(url, null, function success(data) {
                console.log(data)
                var drpCity = $("#drpCity");
                drpCity.empty();
                drpCity.append($('<option/>', {
                    value: 0,
                    text: "-- انتخاب کنید --"
                }));
                $.each(data, function (index, itemData) {
                    drpCity.append($('<option/>', {
                        value: itemData.value,
                        text: itemData.text
                    }));
                });
            }, function error(data) {
            }, "GET", "HTML");
        });
        $("#chkAllCarwashBase").on('change', function () {
            if ($(this).is(":checked"))
                $("input[type=checkbox][name=CarwashBase]").prop("checked", true);
            else
                $("input[type=checkbox][name=CarwashBase]").prop("checked", false);
        });
        $("#chkAllMechanicBase").on('change', function () {
            if ($(this).is(":checked"))
                $("input[type=checkbox][name=MechanicBase]").prop("checked", true);
            else
                $("input[type=checkbox][name=MechanicBase]").prop("checked", false);
        });
        $("#chkAllServiceBase").on('change', function () {
            if ($(this).is(":checked"))
                $("input[type=checkbox][name=ServiceBase]").prop("checked", true);
            else
                $("input[type=checkbox][name=ServiceBase]").prop("checked", false);
        });
        $("#chkAllAccessoryBase").on('change', function () {
            if ($(this).is(":checked"))
                $("input[type=checkbox][name=AccessoryBase]").prop("checked", true);
            else
                $("input[type=checkbox][name=AccessoryBase]").prop("checked", false);
        })
    },
    initRequestServiceList: function () {
        var page = 0;

        $(document).ready(function () {
            LoadServiceRequestList(0);

            //setInterval(function () { LoadServiceRequestList(page); }, 60000)
        });
        $(document).on("click", ".ajax-pager-service-request", function () {
            page = $(this).data("page");
            LoadServiceRequestList(page);
        });

        const LoadServiceRequestList = (page) => {
            var divServiceRequestList = $("#divServiceRequestList");
            var url = "/ServiceRequest/LoadServiceRequestList?page=" + page;
            $.ajax({
                type: "GET",
                url: url,
                success: function (data) {
                    divServiceRequestList.html(data);
                }
            })
        }

        var ServiceRequestId = "";
        var ServiceSateId = 0;
        var ServiceCityId = 0;
        var ServiceServiceTypeId = 0;
        const RefrenceUserModal = $("#divRefrenceUserModal");

        $(document).on("click", ".refrence-user-list", function () {
            ServiceRequestId = $(this).data("servicerequestid");
            ServiceSateId = $(this).data("stateid");
            ServiceCityId = $(this).data("cityid");
            ServiceServiceTypeId = $(this).data("servicetypeid");
            LoadRefrenceUserList();
        });

        const LoadRefrenceUserList = () => {
            Services.loading(true);
            var RefrenceUserList = $("#divRefrenceUserList");
            var url = "/ServiceRequest/LoadRefrenceUserList?serviceRequestId=" + ServiceRequestId + "&serviceTypeId=" + ServiceServiceTypeId + "&stateId=" + ServiceSateId + "&cityId=" + ServiceCityId;
            $.ajax({
                type: "GET",
                url: url,
                success: function (data) {
                    RefrenceUserList.html(data);
                    RefrenceUserModal.modal("show");
                    Services.loading(false);
                }
            })
        }
        RefrenceUserModal.on('hidden.bs.modal', function (e) {
            ServiceRequestId = "";
            ServiceSateId = 0;
            ServiceCityId = 0;
            ServiceServiceTypeId = 0;
        });

        $(document).on("click", ".submuit-refrence", function () {
            Services.loading(true);
            PersonId = $(this).data("personid");
            PersonTypeId = $(this).data("persontypeid");
            var url = "/ServiceRequest/SubmitRefrence";
            var params = {
                ServiceRequestId: ServiceRequestId,
                PersonId: PersonId,
                PersonTypeId: PersonTypeId
            };
            $.ajax({
                type: "POST",
                data: params,
                url: url,
                contentType: "application/x-www-form-urlencoded; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (!data.status)
                        Services.message('', data.error, 'error');
                    else {
                        Services.message('', 'ارجاع با موفقیت انجام شد', 'success');
                        LoadServiceRequestList(page);
                        LoadRefrenceUserList();
                    }
                    Services.loading(false);
                },
                error: function (data) {
                    Services.message('', data.responseText, 'growl-danger');
                    Services.loading(false);
                }
            })
        });
    },

    initModelList: function () {
        var page = 0;

        var ModelId = 0;
        var ModelGalleryId = "";
        const ModelGalleryListModal = $("#divModelGalleryListModal");
        const ModelGalleryModal = $("#divModelGalleryModal");

        $(document).on("click", ".model-gallery-list", function () {
            ModelId = $(this).data("modelid");
            LoadModelGalleryList();
        });

        $(document).on("click", ".model-gallery-edit", function () {
            ModelGalleryId = $(this).data("id");
            LoadModelGalleryEdit();
        });

        $(document).on("click", ".ajax-pager-model-gallery", function () {
            page = $(this).data("page");
            LoadModelGalleryList(page);
        });
        const LoadModelGalleryList = (page) => {
            Services.loading(true);
            var ModelGalleryList = $("#divModelGalleryList");
            var url = "/Model/LoadModelGalleryList?ModelId=" + ModelId + "&page=" + page;
            $.ajax({
                type: "GET",
                url: url,
                success: function (data) {
                    ModelGalleryList.html(data);
                    ModelGalleryListModal.modal("show");
                    Services.loading(false);
                }
            })
        }
        const LoadModelGalleryEdit = () => {
            Services.loading(true);
            var ModelGallery = $("#divModelGallery");
            var url = "/Model/LoadModelGallery?ModelGalleryId=" + ModelGalleryId;
            $.ajax({
                type: "GET",
                url: url,
                success: function (data) {
                    ModelGallery.html(data);
                    ModelGalleryModal.modal("show");
                    Services.loading(false);
                }
            })
        }

        $(document).on("click", ".save-model-image", function () {
            Services.loading(true);
            var formData = new FormData();

            if ($('#customFile')[0].files[0] == undefined) {
                Services.message('', 'انتخاب فایل ضروری است', 'error');
                return false;
            }

            formData.append('ModelId', ModelId);
            formData.append('Id', "");
            formData.append('Title', $('#txtModelGalleryTitle').val());
            formData.append('Description', $('#txtModelGalleryDescription').val());
            formData.append('file', $('#customFile')[0].files[0]);

            var url = "/Model/SaveModelImage";
            $.ajax({
                type: "POST",
                url: url,
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    if (!data.status)
                        Services.message('', data.error, 'error');
                    else {
                        LoadModelGalleryList(page);
                        ModelGalleryModal.modal("hide");
                        Services.message('', 'اطلاعات با موفقیت ثبت شد', 'success');
                    }
                    Services.loading(false);
                },
                error: function (data) {
                    Services.message('', data.responseText, 'error');
                    Services.loading(false);
                }
            })
        });

        $(document).on("click", ".delete-modelImage", function () {
            var Id = $(this).data("id");
            Swal.fire({
                title: 'آیا مطمئنید؟',
                text: "این عمل قابل بازگشت نخواهد بود!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'تایید',
                confirmButtonClass: 'btn btn-primary',
                cancelButtonClass: 'btn btn-danger ml-1',
                cancelButtonText: 'انصراف',
                buttonsStyling: false,
            }).then(function (result) {
                if (result.value) {
                    Services.loading(true);
                    var url = "/Model/DeleteModelImage";
                    var params = {
                        Id: Id
                    };
                    $.ajax({
                        type: "POST",
                        data: params,
                        url: url,
                        contentType: "application/x-www-form-urlencoded; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (!data.status)
                                Services.message('', data.error, 'error');
                            else {
                                Services.message('', 'حذف با موفقیت انجام شد', 'success');
                                LoadModelGalleryList(page);
                            }
                            Services.loading(false);
                        },
                        error: function (data) {
                            Services.message('', data.responseText, 'growl-danger');
                            Services.loading(false);
                        }
                    })
                }
                else
                    return false;
            });
        });

        ModelGalleryListModal.on('hidden.bs.modal', function (e) {
            ModelId = 0;
        });
        ModelGalleryModal.on('hidden.bs.modal', function (e) {
            ModelGalleryId = 0;
        });

    }

}
$(function () {
    MainForm.init();
})