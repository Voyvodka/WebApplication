/*! Ripple.js v1.2.1
 * The MIT License (MIT)
 * Copyright (c) 2014 Jacob Kelley */
!(function (a, b, c) {
  a.ripple = function (d, e) {
    var f = this,
      g = (f.log = function () {
        f.defaults.debug && console && console.log && console.log.apply(console, arguments);
      });
    (f.selector = d),
      (f.defaults = {
        debug: !1,
        on: "mousedown",
        opacity: 0.4,
        color: "auto",
        multi: !1,
        duration: 0.7,
        rate: function (a) {
          return a;
        },
        easing: "linear",
      }),
      (f.defaults = a.extend({}, f.defaults, e));
    var h = function (b) {
      var d,
        e,
        h = a(this);
      if ((h.addClass("has-ripple"), (e = a.extend({}, f.defaults, h.data())), e.multi || (!e.multi && 0 === h.find(".ripple").length))) {
        if (((d = a("<span></span>").addClass("ripple")), d.appendTo(h), g("Create: Ripple"), !d.height() && !d.width())) {
          var i = c.max(h.outerWidth(), h.outerHeight());
          d.css({ height: i, width: i }), g("Set: Ripple size");
        }
        if (e.rate && "function" == typeof e.rate) {
          var j = c.round(d.width() / e.duration),
            k = e.rate(j),
            l = d.width() / k;
          e.duration.toFixed(2) !== l.toFixed(2) && (g("Update: Ripple Duration", { from: e.duration, to: l }), (e.duration = l));
        }
        var m = "auto" == e.color ? h.css("color") : e.color,
          n = { animationDuration: e.duration.toString() + "s", animationTimingFunction: e.easing, background: m, opacity: e.opacity };
        g("Set: Ripple CSS", n), d.css(n);
      }
      e.multi || (g("Set: Ripple Element"), (d = h.find(".ripple"))), g("Destroy: Ripple Animation"), d.removeClass("ripple-animate");
      var o = b.pageX - h.offset().left - d.width() / 2,
        p = b.pageY - h.offset().top - d.height() / 2;
      e.multi &&
        (g("Set: Ripple animationend event"),
        d.one("animationend webkitAnimationEnd oanimationend MSAnimationEnd", function () {
          g("Note: Ripple animation ended"), g("Destroy: Ripple"), a(this).remove();
        })),
        g("Set: Ripple location"),
        g("Set: Ripple animation"),
        d.css({ top: p + "px", left: o + "px" }).addClass("ripple-animate");
    };
    a(b).on(f.defaults.on, f.selector, h);
  };
})(jQuery, document, Math);
$.ripple.version = "1.2.1";
