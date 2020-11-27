!(function (o, r, p) {
    "use strict";

    $.validator.setDefaults({
        errorPlacement: function (error, element) {
            element.addClass("is-invalid");
            //element.removeClass("is-valid");
        },
        highlight: function (element) {
            element = $(element);
            //element.removeClass("is-valid");
            element.addClass("is-invalid");
        },
        unhighlight: function (element) {
            element = $(element);
            element.removeClass("is-invalid");
            //element.addClass("is-valid");
        },
        errorElement: "span",
        ignore: ":hidden:not(.force-validation)"
    });

   

    var c = p("html"),
        d = p("body"),
        u = "#FF5B5C";
    if (
        (p(o).scroll(function () {
            var e;
            60 < (e = p(o).scrollTop()) ? p("body").addClass("navbar-scrolled") : p("body").removeClass("navbar-scrolled"), 20 < e ? p("body").addClass("page-scrolled") : p("body").removeClass("page-scrolled");
        }),
            p(o).on("load", function () {
                var a = !1;
                function e(e) {
                    e.updateLiviconEvo({
                        strokeColor: menuActiveIconColorsObj.iconStrokeColor,
                        solidColor: menuActiveIconColorsObj.iconSolidColor,
                        fillColor: menuActiveIconColorsObj.iconFillColor,
                        strokeColorAlt: menuActiveIconColorsObj.iconStrokeColorAlt,
                    });
                }
                d.hasClass("menu-collapsed") && (a = !0),
                    p("html").data("textdirection"),
                    setTimeout(function () {
                        c.removeClass("loading").addClass("loaded");
                    }, 1200),
                    p.app.menu.init(a),
                    p.each(p(".menu-livicon"), function (e) {
                        var a = p(this),
                            n = a.data("icon"),
                            t = p("#main-menu-navigation").data("icon-style");
                        a.addLiviconEvo({
                            name: n,
                            style: t,
                            duration: 0.85,
                            strokeWidth: "1.3px",
                            eventOn: "none",
                            strokeColor: menuIconColorsObj.iconStrokeColor,
                            solidColor: menuIconColorsObj.iconSolidColor,
                            fillColor: menuIconColorsObj.iconFillColor,
                            strokeColorAlt: menuIconColorsObj.iconStrokeColorAlt,
                            afterAdd: function () {
                                e === p(".main-menu-content .menu-livicon").length - 1 &&
                                    p(".main-menu-content .nav-item a").on("mouseenter", function () {
                                        p(".main-menu-content .menu-livicon").length && (p(".main-menu-content .menu-livicon").stopLiviconEvo(), p(this).find(".menu-livicon").playLiviconEvo());
                                    });
                            },
                        });
                    });
                !1 === p.app.nav.initialized && p.app.nav.init({ speed: 300 }),
                    Unison.on("change", function (e) {
                        p.app.menu.change(a);
                    }),
                    p('[data-toggle="tooltip"]').tooltip({ container: "body" }),
                    p(".tooltip-horizontal-bookmark").tooltip({ customClass: "tooltip-horizontal-bookmark" }),
                    0 < p(".navbar-hide-on-scroll").length &&
                    (p(".navbar-hide-on-scroll.fixed-top").headroom({ offset: 205, tolerance: 5, classes: { initial: "headroom", pinned: "headroom--pinned-top", unpinned: "headroom--unpinned-top" } }),
                        p(".navbar-hide-on-scroll.fixed-bottom").headroom({ offset: 205, tolerance: 5, classes: { initial: "headroom", pinned: "headroom--pinned-bottom", unpinned: "headroom--unpinned-bottom" } })),
                    p('a[data-action="collapse"]').on("click", function (e) {
                        e.preventDefault(),
                            p(this).closest(".card").children(".card-content").collapse("toggle"),
                            p(this).closest(".card").children(".card-header").css("padding-bottom", "1.5rem"),
                            p(this).closest(".card").find('[data-action="collapse"]').toggleClass("rotate");
                    }),
                    p('a[data-action="expand"]').on("click", function (e) {
                        e.preventDefault(), p(this).closest(".card").find('[data-action="expand"] i').toggleClass("bx-fullscreen bx-exit-fullscreen"), p(this).closest(".card").toggleClass("card-fullscreen");
                    }),
                    p(".scrollable-container").each(function () {
                        new PerfectScrollbar(p(this)[0], { wheelPropagation: !1 });
                    }),
                    p('a[data-action="reload"]').on("click", function () {
                        var e = p(this).closest(".card").find(".card-content");
                        if (d.hasClass("dark-layout")) var a = "#10163a";
                        else a = "#fff";
                        e.block({ message: '<div class="bx bx-sync icon-spin font-medium-2 text-primary"></div>', timeout: 2e3, overlayCSS: { backgroundColor: a, cursor: "wait" }, css: { border: 0, padding: 0, backgroundColor: "none" } });
                    }),
                    p('a[data-action="close"]').on("click", function () {
                        p(this).closest(".card").removeClass().slideUp("fast");
                    }),
                    setTimeout(function () {
                        p(".row.match-height").each(function () {
                            p(this).find(".card").not(".card .card").matchHeight();
                        });
                    }, 500),
                    p('.card .heading-elements a[data-action="collapse"]').on("click", function () {
                        var e,
                            a = p(this).closest(".card");
                        0 < parseInt(a[0].style.height, 10) ? ((e = a.css("height")), a.css("height", "").attr("data-height", e)) : a.data("height") && ((e = a.data("height")), a.css("height", e).attr("data-height", ""));
                    }),
                    p(".main-menu-content").find("li.active").parents("li").addClass("sidebar-group-active"),
                    p(".nav-item.active .menu-livicon").length && e(p(".nav-item.active .menu-livicon")),
                    p(".main-menu-content li.sidebar-group-active .menu-livicon").length && e(p(".main-menu-content li.sidebar-group-active .menu-livicon"));
                var n = d.data("menu");
                "horizontal-menu" != n && !1 === a && p(".main-menu-content").find("li.active").parents("li").addClass("open"),
                    "horizontal-menu" == n && (p(".main-menu-content").find("li.active").parents("li:not(.nav-item)").addClass("open"), p(".main-menu-content").find("li.active").parents("li").addClass("active")),
                    p(".heading-elements-toggle").on("click", function () {
                        p(this).next(".heading-elements").toggleClass("visible");
                    });
                var t = p(".chartjs"),
                    s = t.children("canvas").attr("height");
                if ((t.css("height", s), d.hasClass("boxed-layout") && d.hasClass("vertical-overlay-menu"))) {
                    var o = p(".main-menu").width(),
                        i = p(".app-content").position().left - o;
                    d.hasClass("menu-flipped") ? p(".main-menu").css("right", i + "px") : p(".main-menu").css("left", i + "px");
                }
                p(document).on("change",".custom-file input",function (e) {
                    p(this).next(".custom-file-label").html(e.target.files[0].name);
                }),
                    p(".char-textarea").on("keyup", function (e) {
                        !(function (e, a) {
                            var n = parseInt(p(e).data("length"));
                            (t = a), 8 != t.keyCode && 46 != t.keyCode && 37 != t.keyCode && 38 != t.keyCode && 39 != t.keyCode && 40 != t.keyCode && e.value.length < n - 1 && (e.value = e.value.substring(0, n));
                            var t;
                            p(".char-count").html(e.value.length),
                                e.value.length > n
                                    ? (p(".counter-value").css("background-color", u), p(".char-textarea").css("color", u), p(".char-textarea").addClass("max-limit"))
                                    : (p(".counter-value").css("background-color", "#5A8DEE"), p(".char-textarea").css("color", "#304156"), p(".char-textarea").removeClass("max-limit"));
                        })(this, e),
                            p(this).addClass("active");
                    }),
                    p(".content-overlay").on("click", function () {
                        p(".search-list").removeClass("show"), p(".app-content").removeClass("show-overlay"), p(".bookmark-wrapper .bookmark-input").removeClass("show");
                    });
                var l = r.getElementsByClassName("main-menu-content");
                0 < l.length &&
                    l[0].addEventListener("ps-scroll-y", function () {
                        0 < p(this).find(".ps__thumb-y").position().top ? p(".shadow-bottom").css("display", "block") : p(".shadow-bottom").css("display", "none");
                    });
            }),
            p(r).on("click", ".sidenav-overlay", function (e) {
                return p.app.menu.hide(), !1;
            }),
            "undefined" != typeof Hammer)
    ) {
        var e = r.querySelector(".drag-target");
        if (0 < p(e).length)
            new Hammer(e).on("panright", function (e) {
                if (d.hasClass("vertical-overlay-menu")) return p.app.menu.open(), !1;
            });
        setTimeout(function () {
            var e,
                a = r.querySelector(".main-menu");
            0 < p(a).length &&
                ((e = new Hammer(a)).get("pan").set({ direction: Hammer.DIRECTION_ALL, threshold: 100 }),
                    e.on("panleft", function (e) {
                        if (d.hasClass("vertical-overlay-menu")) return p.app.menu.hide(), !1;
                    }));
        }, 300);
        var a = r.querySelector(".sidenav-overlay");
        if (0 < p(a).length)
            new Hammer(a).on("panleft", function (e) {
                if (d.hasClass("vertical-overlay-menu")) return p.app.menu.hide(), !1;
            });
    }
    p(r).on("click", ".menu-toggle, .modern-nav-toggle", function (e) {
        return (
            e.preventDefault(),
            p.app.menu.toggle(),
            setTimeout(function () {
                p(o).trigger("resize");
            }, 200),
            0 < p("#collapsed-sidebar").length &&
            setTimeout(function () {
                d.hasClass("menu-expanded") || d.hasClass("menu-open") ? p("#collapsed-sidebar").prop("checked", !1) : p("#collapsed-sidebar").prop("checked", !0);
            }, 1e3),
            p(".vertical-overlay-menu .navbar-with-menu .navbar-container .navbar-collapse").hasClass("show") && p(".vertical-overlay-menu .navbar-with-menu .navbar-container .navbar-collapse").removeClass("show"),
            !1
        );
    }),
        p(".navigation").find("li").has("ul").addClass("has-sub"),
        p(".carousel").carousel({ interval: 2e3 }),
        p(".nav-link-expand").on("click", function (e) {
            "undefined" != typeof screenfull && screenfull.enabled && screenfull.toggle();
        }),
        "undefined" != typeof screenfull &&
        screenfull.enabled &&
        p(r).on(screenfull.raw.fullscreenchange, function () {
            screenfull.isFullscreen
                ? (p(".nav-link-expand").find("i").toggleClass("bx-exit-fullscreen bx-fullscreen"), p("html").addClass("full-screen"))
                : (p(".nav-link-expand").find("i").toggleClass("bx-fullscreen bx-exit-fullscreen"), p("html").removeClass("full-screen"));
        }),
        p(r).ready(function () {
            p(".step-icon").each(function () {
                var e = p(this);
                0 < e.siblings("span.step").length && (e.siblings("span.step").empty(), p(this).appendTo(p(this).siblings("span.step")));
            });
        }),
        p(o).resize(function () {
            p.app.menu.manualScroller.updateHeight();
            var e = r.getElementsByClassName("main-menu-content");
            0 < e.length &&
                e[0].addEventListener("ps-scroll-y", function () {
                    0 < p(this).find(".ps__thumb-y").position().top ? p(".shadow-bottom").css("display", "block") : p(".shadow-bottom").css("display", "none");
                });
        }),
        p("#sidebar-page-navigation").on("click", "a.nav-link", function (e) {
            e.preventDefault(), e.stopPropagation();
            var a = p(this),
                n = a.attr("href"),
                t = p(n).offset().top - 80;
            p("html, body").animate({ scrollTop: t }, 0),
                setTimeout(function () {
                    a.parent(".nav-item").siblings(".nav-item").children(".nav-link").removeClass("active"), a.addClass("active");
                }, 100);
        }),
        p(".dropdown-language .dropdown-item").on("click", function () {
            var e = p(this);
            e.siblings(".selected").removeClass("selected"), e.addClass("selected");
            var a = e.text(),
                n = e.find(".flag-icon").attr("class");
            p("#dropdown-flag .selected-language").text(a), p("#dropdown-flag .flag-icon").removeClass().addClass(n);
            var t = e.data("language");
            i18next.changeLanguage(t, function (e, a) {
                p(".main-menu").localize();
            });
        });
    var h = p(".search-input input").data("search");
    p(".bookmark-wrapper .bookmark-star").on("click", function (e) {
        e.stopPropagation(),
            p(".bookmark-wrapper .bookmark-input").toggleClass("show"),
            p(".bookmark-wrapper .bookmark-input input").val(""),
            p(".bookmark-wrapper .bookmark-input input").blur(),
            p(".bookmark-wrapper .bookmark-input input").focus(),
            p(".bookmark-wrapper .search-list").addClass("show");
        var a = p("ul.nav.navbar-nav.bookmark-icons li"),
            n = "";
        p("ul.search-list li").remove();
        for (var t = 0; t < a.length; t++)
            n +=
                '<li class="auto-suggestion d-flex align-items-center justify-content-between cursor-pointer ' +
                (0 === t ? "current_item" : "") +
                '"><a class="d-flex align-items-center justify-content-between w-100" href=' +
                a[t].firstChild.href +
                '><div class="d-flex justify-content-start"><span class="mr-75 ' +
                a[t].firstChild.firstChild.className +
                '"  data-icon="' +
                a[t].firstChild.firstChild.className +
                '"></span><span>' +
                a[t].firstChild.dataset.originalTitle +
                '</span></div><span class="float-right bookmark-icon bx bx-star warning"></span></a></li>';
        p("ul.search-list").append(n);
    }),
        p(".nav-link-search").on("click", function () {
            p(this);
            p(this).parent(".nav-search").find(".search-input").addClass("open"),
                p(".search-input input").focus(),
                p(".search-input .search-list li").remove(),
                p(".search-input .search-list").addClass("show"),
                p(".bookmark-wrapper .bookmark-input").removeClass("show");
        }),
        p(".search-input-close i").on("click", function () {
            p(this);
            var e = p(this).closest(".search-input");
            e.hasClass("open") &&
                (e.removeClass("open"),
                    p(".search-input input").val(""),
                    p(".search-input input").blur(),
                    p(".search-input .search-list").removeClass("show"),
                    p(".app-content").hasClass("show-overlay") && p(".app-content").removeClass("show-overlay"));
        }),
        p(".app-content").on("click", function () {
            var e = p(".search-input-close"),
                a = p(e).parent(".search-input");
            a.hasClass("open") && a.removeClass("open");
        }),
        p(".search-input .input").on("keyup", function (e) {
            if (38 !== e.keyCode && 40 !== e.keyCode && 13 !== e.keyCode) {
                27 == e.keyCode &&
                    (p(".app-content").removeClass("show-overlay"),
                        p(".bookmark-input input").val(""),
                        p(".bookmark-input input").blur(),
                        p(".search-input input").val(""),
                        p(".search-input input").blur(),
                        p(".search-input").removeClass("open"),
                        p(".search-list").hasClass("show") && (p(this).removeClass("show"), p(".search-input").removeClass("show")));
                var s = p(this).val().toLowerCase(),
                    o = "",
                    i = !1;
                if ((p("ul.search-list li").remove(), p(this).parent().hasClass("bookmark-input") && (i = !0), "" != s)) {
                    p(".app-content").addClass("show-overlay"),
                        p(".bookmark-input").focus() ? p(".bookmark-input .search-list").addClass("show") : (p(".search-input .search-list").addClass("show"), p(".bookmark-input .search-list").removeClass("show")),
                        !1 === i && (p(".search-input .search-list").addClass("show"), p(".bookmark-input .search-list").removeClass("show"));
                    var l = "",
                        r = "",
                        c = "",
                        d = "",
                        u = 0;
                    p.getJSON("../../../app-assets/data/" + h + ".json", function (e) {
                        for (var a = 0; a < e.listItems.length; a++) {
                            if (!0 === i) {
                                o = "";
                                for (var n = p("ul.nav.navbar-nav.bookmark-icons li"), t = 0; t < n.length; t++) {
                                    if (e.listItems[a].name === n[t].firstChild.dataset.originalTitle) {
                                        o = " warning";
                                        break;
                                    }
                                    o = "";
                                }
                                d = '<span class="float-right bookmark-icon bx bx-star' + o + '"></span>';
                            }
                            ((0 == e.listItems[a].name.toLowerCase().indexOf(s) && u < 10) || (0 != e.listItems[a].name.toLowerCase().indexOf(s) && -1 < e.listItems[a].name.toLowerCase().indexOf(s) && u < 10)) &&
                                ((l +=
                                    '<li class="auto-suggestion d-flex align-items-center justify-content-between cursor-pointer ' +
                                    (0 === u ? "current_item" : "") +
                                    '"><a class="d-flex align-items-center justify-content-between w-100" href=' +
                                    e.listItems[a].url +
                                    '><div class="d-flex justify-content-start"><span class="mr-75 ' +
                                    e.listItems[a].icon +
                                    '" data-icon="' +
                                    e.listItems[a].icon +
                                    '"></span><span>' +
                                    e.listItems[a].name +
                                    "</span></div>" +
                                    d +
                                    "</a></li>"),
                                    u++);
                        }
                        for (a = 0; a < e.listItems.length; a++) {
                            if (!0 === i) {
                                o = "";
                                for (n = p("ul.nav.navbar-nav.bookmark-icons li"), t = 0; t < n.length; t++) o = e.listItems[a].name === n[t].firstChild.dataset.originalTitle ? " warning" : "";
                                d = '<span class="float-right bookmark-icon bx bx-star' + o + '"></span>';
                            }
                            0 != e.listItems[a].name.toLowerCase().indexOf(s) &&
                                -1 < e.listItems[a].name.toLowerCase().indexOf(s) &&
                                u < 10 &&
                                ((r +=
                                    '<li class="auto-suggestion d-flex align-items-center justify-content-between cursor-pointer ' +
                                    (0 === u ? "current_item" : "") +
                                    '"><a class="d-flex align-items-center justify-content-between w-100" href=' +
                                    e.listItems[a].url +
                                    '><div class="d-flex justify-content-start"><span class="mr-75 ' +
                                    e.listItems[a].icon +
                                    '" data-icon="' +
                                    e.listItems[a].icon +
                                    '"></span><span>' +
                                    e.listItems[a].name +
                                    "</span></div>" +
                                    d +
                                    "</a></li>"),
                                    u++);
                        }
                        "" == l &&
                            "" == r &&
                            (r =
                                '<li class="auto-suggestion d-flex align-items-center justify-content-between cursor-pointer"><a class="d-flex align-items-center justify-content-between w-100"><div class="d-flex justify-content-start"><span class="mr-75 bx bx-error-circle"></span><span>No results found.</span></div></a></li>'),
                            (c = l.concat(r)),
                            p("ul.search-list").html(c);
                    });
                } else if (!0 === i) {
                    for (var a = p("ul.nav.navbar-nav.bookmark-icons li"), n = "", t = 0; t < a.length; t++)
                        0 === t ? "current_item" : "",
                            (n +=
                                '<li class="auto-suggestion d-flex align-items-center justify-content-between cursor-pointer"><a class="d-flex align-items-center justify-content-between w-100" href=' +
                                a[t].firstChild.href +
                                '><div class="d-flex justify-content-start"><span class="mr-75 ' +
                                a[t].firstChild.firstChild.className +
                                '"  data-icon="' +
                                a[t].firstChild.firstChild.className +
                                '"></span><span>' +
                                a[t].firstChild.dataset.originalTitle +
                                '</span></div><span class="float-right bookmark-icon bx bx-star warning"></span></a></li>');
                    p("ul.search-list").append(n);
                } else p(".app-content").hasClass("show-overlay") && p(".app-content").removeClass("show-overlay"), p(".search-list").hasClass("show") && p(".search-list").removeClass("show");
            }
        }),
        p(r).on("mouseenter", ".search-list li", function (e) {
            p(this).siblings().removeClass("current_item"), p(this).addClass("current_item");
        }),
        p(r).on("click", ".search-list li", function (e) {
            e.stopPropagation();
        }),
        p("html").on("click", function (e) {
            p(e.target).hasClass("bookmark-icon") ||
                (p(".bookmark-input .search-list").hasClass("show") && p(".bookmark-input .search-list").removeClass("show"), p(".bookmark-input").hasClass("show") && p(".bookmark-input").removeClass("show"));
        }),
        p(r).on("click", ".bookmark-input .search-list .bookmark-icon", function (e) {
            if ((e.stopPropagation(), p(this).hasClass("warning"))) {
                p(this).removeClass("warning");
                for (var a = p("ul.nav.navbar-nav.bookmark-icons li"), n = 0; n < a.length; n++) a[n].firstChild.dataset.originalTitle == p(this).parent()[0].innerText && a[n].remove();
                e.preventDefault();
            } else {
                a = p("ul.nav.navbar-nav.bookmark-icons li");
                p(this).addClass("warning"), e.preventDefault();
                var t;
                (t =
                    '<li class="nav-item d-none d-lg-block"><a class="nav-link" href="' +
                    p(this).parent()[0].href +
                    '" data-toggle="tooltip" data-placement="top" title="' +
                    p(this).parent()[0].innerText +
                    '"><i class="ficon ' +
                    p(this).parent()[0].firstChild.firstChild.dataset.icon +
                    '"></i></a></li>'),
                    p("ul.nav.bookmark-icons").append(t),
                    p('[data-toggle="tooltip"]').tooltip();
            }
        }),
        p(o).on("keydown", function (e) {
            var a,
                n,
                t = p(".search-list li.current_item");
            if (
                (40 === e.keyCode ? ((a = t.next()), t.removeClass("current_item"), (t = a.addClass("current_item"))) : 38 === e.keyCode && ((n = t.prev()), t.removeClass("current_item"), (t = n.addClass("current_item"))),
                    13 === e.keyCode && 0 < p(".search-list li.current_item").length)
            ) {
                var s = p(".search-list li.current_item a");
                (o.location = s.attr("href")), p(s).trigger("click");
            }
        }),
        20 < p(o).scrollTop() &&
        (p(".navbar-sticky .main-header-navbar").css({ "background-color": "#ffff", "box-shadow": "none" }),
        p(".navbar-static .main-header-navbar").css({ "background-color": "#ffff", "box-shadow": "-8px 12px 18px 0 rgba(25, 42, 70, 0.13)" })),
        p(o).scroll(function () {
            20 < p(this).scrollTop()
                ? p(".navbar-sticky .main-header-navbar").css({ "background-color": "#ffff", "box-shadow": "-8px 12px 18px 0 rgba(25, 42, 70, 0.13)" })
                : p(".navbar-sticky .main-header-navbar").css({ "background-color": "#ffff", "box-shadow": "none" }),
                p(".navbar-static .main-header-navbar").css({ "background-color": "#ffff", "box-shadow": "-8px 12px 18px 0 rgba(25, 42, 70, 0.13)" });
        }),
        20 < p(o).scrollTop() && p(".dark-layout.navbar-sticky .main-header-navbar").css({ "background-color": "#272e48", "box-shadow": "rgba(26, 35, 59, .70) -8px 12px 18px 0px" }),
        p(o).scroll(function () {
            20 < p(this).scrollTop()
                ? p(".dark-layout.navbar-sticky .main-header-navbar").css({ "background-color": "#272e48", "box-shadow": "rgba(26, 35, 59, .70) -8px 12px 18px 0px" })
                : p(".dark-layout.navbar-sticky .main-header-navbar").css({ "background-color": "transparent", "box-shadow": "none" });
        }),
        p(".header-navbar .dropdown-notification label").on("click", function (e) {
            e.stopPropagation();
        });
})(window, document, jQuery);
