/*****************************************************************
 *
 * $.fn.anchorNav()
 * by rebecca murphey
 * rmurphey gmail com
 * http://blog.rebeccamurphey.com/2007/12/24/anchor-based-url-navigation-jquery-plugin/
 *
 * Call this function on an element that contains 
 * "panels" which, in turn, contain anchors. The container
 * element should contain ONLY related panels, as this plugin
 * will show only one first-child element of the container at once.
 *
 * Options:
 *
 *   showFn: function to show the current panel
 *   hideFn: function to hide the current panel's siblings
 *   nav: selector for the page's navigation 
 *   currentNavFn: function to run on the link in the nav
 *               that is associated with the anchor
 *   anchorClass: class assigned to anchor tags; setting this will
 *                improve the speed on pages with lots of links
 *   noAnchorFn: function to run if the URL does not contain an anchor
 *
 * See below for default option values. See the URL above for 
 * detailed documentation.
 *
 ************************************************************************/


(function($) {
  $.fn.anchorNav = function(userOptions) {
    var options = {
      showFn: function() { $(this).show(); },
      hideFn: function() { $(this).hide(); },
      nav: null,
      currentNavFn: 
        function() { 
          // this will add a class to the parent of the
          // link that matches the currently selected anchor
          $(this).parent().siblings().removeClass('anchor-nav-current'); 
          $(this).parent().addClass('anchor-nav-current'); 
        },
      anchorClass: null,
      noAnchorFn: 
        function() { 
          // this will show the first panel
          // if the URL doesn't contain an anchor
          $container.children().hide().eq(0).show(); 
        }
    };

    if (userOptions) { $.extend(true,options,userOptions); }

    var $container = $(this);

    if (options.anchorClass) {
      var $containerAnchors = 
        $container.
        find('a.' + options.anchorClass);
    } else {
      var $containerAnchors = 
        $container.
        find('a[name]');
    }

    var url = document.location.toString();

    // look at the URL to see if it contains an anchor
    if (url.match('#')) {

      // if so, get it from the URL
      var urlAnchor = url.split('#')[1];

      // look for the panel that contains the anchor
      var $currentPanel = 
        $containerAnchors.
        filter('[name="' + urlAnchor +'"]').
        parent();

      // show that panel, and hide its siblings
      $currentPanel.siblings().each(options.hideFn);
      $currentPanel.each(options.showFn);

      // if a nav selector was defined, 
      // mark the current nav item using the
      // currentNav function
      if (options.nav) {
        // find the link associated with the
        // current anchor
        var $currentNav = $(options.nav).find('a[href="#' + urlAnchor + '"]');
        // run the currentNav function
        $currentNav.each(options.currentNavFn);
      };

    // if the URL doesn't contain an anchor, 
    // execute the noAnchor option
    } else { options.noAnchorFn(); }

    if (options.nav) {
      $containerAnchors.each(function() {
        var $panel = $(this).parent();
        var name = $(this).attr('name');
        var $nav = $(options.nav);
        $nav.
          find('a[href="#' + name + '"]').
          click(function() { 
            $panel.siblings().each(options.hideFn);
            $panel.each(options.showFn);
          });
      });
    }
    return $container;

  }

})(jQuery);
