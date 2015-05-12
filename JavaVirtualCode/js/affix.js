// JavaScript Document
/*!
 * Adapted from Bootstrap docs JavaScript
 */
  $(function () {
    var $window = $(window)
    var $body   = $(document.body)

    //var navHeight = $('.navbar').outerHeight(true) + 10

    $body.scrollspy({
      target: '.sidebar'
      //offset: navHeight
    });

    $window.on('load', function () {
      $body.scrollspy('refresh')
    });

    // back to top
    setTimeout(function () {
      var $sideBar = $('.sidebar');
      $sideBar.affix({
        offset: {
            top: 120,
            bottom: function () {
                return (this.bottom = $('.footer').outerHeight(true))
            }
        }
      });
    }, 100);

  })


