$(document).ready(function(){
  // scrolling -----------------------
        $(document).ready(function(){
        let scroll_link = $('.scroll');
        });
         //sticky menu while scrolling -----------------------
        window.onscroll = function() {myFunction()};

        var navbar = document.getElementById("navbar");
        var sticky = navbar.offsetTop;

        function myFunction() {
        if (window.pageYOffset >= 1) {
            navbar.classList.add("sticky")
        } 
        else {
            navbar.classList.remove("sticky");
        }
        }     
  
/*========== Responsive Toggle ========= */  


  let burger = document.getElementById('burger'),
   nav    = document.getElementById('main-nav');

burger.addEventListener('click', function(e){
  this.classList.toggle('is-open');
  nav.classList.toggle('is-open');
});


// $(".nav_manu a.toggle_menu").click(function(){
//    		 $(".Menu_list").toggleClass('active');
//      });

//  $(".hamburger").click(function(){
//     $(this).toggleClass("is-active");
//   });

/*========== Responsive Toggle ========= */

/*========== Testimonials Slider ========= */

 $('.testi_slider').slick({
        dots: false,
        infinite: true,
        speed: 1800,
        fade: false,
        arrows: true,
        autoplaySpeed: 4000,
        autoplayHoverPause: true,
        autoplay: true,
        autoplayTimeout: 8000,
    });
	
/*========== Testimonials Slider ========= */


/*========== According  ========= */
 if($(window).width() < 768){ 
		
 $(".M_footer .title").click(function() {
           if($(this).hasClass('fiaccDiv')){
			   $(this).removeClass("fiaccDiv").next().slideUp();			  
			   }
		else
		{
			$(".M_footer .title").removeClass("fiaccDiv");
			$(".main_cnt").slideUp();
			$(this).addClass("fiaccDiv");
			$(this).next().slideDown();
			
		}           
        });

 }
 
 /*========== According  ========= */

  /*========== login validation  ========= */

  $(".loginbutton").click(function () {            
        var form = $("#loginform");
            form.validate({
               //ignore: ":not(:visible)",
                errorElement: 'span',
                errorClass: 'help-block',
                rules: {
                    emailaddress: {
                        required: true,
                        email: true
                    },
                    password: {
                        minlength:10,
                        required: true,
                    },
                },
                messages: {
                  password: {
                      required: "Please enter your valid password",
                      minlength: "Enter at least 10 character"
                  },
                  emailaddress: {
                      required: "Please enter your email address",
                      email: "Please enter a valid email address"
                  },
                }
            });
        });

 /*========== New Account validation  ========= */
  $(".register-btn").click(function () {            
        var form = $("#registrationform");
            form.validate({
               //ignore: ":not(:visible)",
                errorElement: 'span',
                errorClass: 'help-block',
                rules: {
                    registeremail: {
                        required: true,
                        email: true
                    },
                   
                },
                messages: {
                
                  registeremail: {
                      required: "Please enter your email address",
                      email: "Please enter a valid email address"
                  },
                }
            });
        });
 /*========== New Account validation  ========= */
   $(".subscribebutton").click(function () {            
        var form = $("#subscribeform");
            form.validate({
               //ignore: ":not(:visible)",
                errorElement: 'span',
                errorClass: 'help-block',
                rules: {
                    subscribeemail: {
                        required: true,
                        email: true
                    },
                   
                },
                messages: {
                
                  subscribeemail: {
                      required: "Please enter your email address",
                      email: "Please enter a valid email address"
                  },
                }
            });
        });
    /*========== New Account validation  ========= */
     $(".checkout-btn").click(function () {            
        var form = $("#checkoutform");
            form.validate({
               //ignore: ":not(:visible)",
                errorElement: 'span',
                errorClass: 'help-block',
                rules: {
                    firstname: {
                        required: true,
                    },
                    lastname: {
                        required: true,
                    },
                    checkoutemail: {
                        required: true,
                        email: true
                    },
                    phone: {
                        required: true,
                        number: true
                      },
                    address: {
                        required: true,
                    },
                    postcode: {
                        required: true,
                        number: true
                      },
                    town: {
                        required:true,
                      },
                   
                },
                messages: {
                   firstname: "Please enter your first name",
                   lastname: "Please Enter your last name",
                
                  checkoutemail: {
                      required: "Please enter your email address",
                      email: "Please enter a valid email address"
                  },
                   phone: {
                        required: "Please enter your contact number",
                        number: "enter number"
                      },
                   address: "Please Enter your address",  

                  postcode: {
                        required: "Please enter Post Code",
                        number: "enter valid code"
                     },
                    town: "Please Enter your town",  
                }

            });
        });
      /*========== New Account validation  ========= */
      $(".contactus-btn").click(function () {            
        var form = $("#contactusform");
            form.validate({
               //ignore: ":not(:visible)",
                errorElement: 'span',
                errorClass: 'help-block',
                rules: {
                    fname: {
                        required: true,
                    },
                    lname: {
                        required: true,
                    },
                    subject: {
                        required: true,
                    },
                    message: {
                        required: true,
                    },
                   
                },
                messages: {
                   fname: "Please Enter your first name",
                   lname: "Please Enter your last name",
                   subject: "Please Enter your subject",
                   message: "Please Enter your message",
                }

            });
        });
    /*========== New Account validation  ========= */
         $(".coupon-btn").click(function () {            
        var form = $("#couponform");
            form.validate({
               //ignore: ":not(:visible)",
                errorElement: 'span',
                errorClass: 'help-block',
                rules: {
                    Coupancode: {
                        required: true,
                    },
                   
                },
                messages: {
                   Coupancode: "Please enter your Coupan code ",
                }

            });
        });
});
/*========== submit complaint validation  ========= */
      $(".submitcomplaintbtn").click(function () {            
        var form = $("#submitcomplaint");
            form.validate({
               //ignore: ":not(:visible)",
                errorElement: 'span',
                errorClass: 'help-block',
                rules: {
                    bookingid: {
                        required: true,
                    },
                    subject: {
                        required: true,
                    },
                    problem: {
                        required: true,
                    },
                   
                },
                messages: {
                   bookingid: "Please Enter your booking id",
                   subject: "Please Enter subject",
                   problem: "Please Enter your problem",
                }

            });
        });

/*========== Personal Information validation  ========= */
      $(".PersonalInfoBtn").click(function () {            
        var form = $("#userpersonalinfo");
            form.validate({
               //ignore: ":not(:visible)",
                errorElement: 'span',
                errorClass: 'help-block',
                rules: {
                    fname: {
                        required: true,
                    },
                    lname: {
                        required: true,
                    },
                    email: {
                        required: true,
                        email: true
                    },
                    contact: {
                        required: true,
                    },
                    currentaddress: {
                        required: true,
                    },
                    zipcode: {
                        required: true,
                    },
                    City: {
                        required: true,
                    },
                    country: {
                        required: true,
                    },
                    state: {
                        required: true,
                    },
                   
                },
                messages: {
                   bookingid: "Please Enter your booking id",
                   subject: "Please Enter subject",
                   problem: "Please Enter your problem",
                   fname: "Please Enter your first name",
                    lname: "Please Enter your last name",
                    email: {
                      required: "Please enter your email address",
                      email: "Please enter a valid email address"
                  },
                    contact: "Please Enter your contact",
                    currentaddress: "Please Enter your current address",
                    zipcode: "Please Enter zip code",
                    City: "Please Enter your City name",
                    country: "Please Enter your country name",
                    state: "Please Enter your state name",
                }

            });
        });

    /*========== user change password validation  ========= */
      $(".changepasswordbtn").click(function () {            
        var form = $("#changepasswordbody");
            form.validate({
               //ignore: ":not(:visible)",
                errorElement: 'span',
                errorClass: 'help-block',
                rules: {
                    oldpassword: {
                        required: true,
                    },
                    newpassword: {
                        required: true,
                    },
                    confirmpassword: {
                        required: true,
                        equalTo: "#newpassword",
                    },
                   
                },
                messages: {
                   oldpassword: "Please Enter your old password",
                   newpassword: "Please Enter your new password",
                   confirmpassword: {
                      required: "Please Enter your new password again",
                      equalTo: "password must be same",
                  },
                }

            });
        });
  
   /*========== billing shiping address validation  ========= */
      $(".BillingAddbtn").click(function () {            
        var form = $("#BillingAdd");
            form.validate({
               //ignore: ":not(:visible)",
                errorElement: 'span',
                errorClass: 'help-block',
                rules: {
                    address: {
                        required: true,
                    },
                    emailaddress: {
                        required: true,
                        email: true,
                    },
                    password: {
                        required: true,
                    },
                   
                },
                messages: {
                   address: "Please Enter your address",
                   emailaddress:  {
                      required: "Please enter your email address",
                      email: "Please enter a valid email address"
                  },
                   password: {
                      required: "Please Enter your new password again",
                  },
                }

            });
        });
  
    $(".ShippingAddbtn").click(function () {            
        var form = $("#ShippingAdd");
            form.validate({
               //ignore: ":not(:visible)",
                errorElement: 'span',
                errorClass: 'help-block',
                rules: {
                    address: {
                        required: true,
                    },
                    emailaddress: {
                        required: true,
                        email: true,
                    },
                    password: {
                        required: true,
                    },
                   
                },
                messages: {
                   address: "Please Enter your address",
                   emailaddress:  {
                      required: "Please enter your email address",
                      email: "Please enter a valid email address"
                  },
                   password: {
                      required: "Please Enter your new password again",
                  },

                }

            });
        });


     /*========== Add New Card validation  ========= */
      $(".AddNewCardbtn").click(function () {            
        var form = $("#AddNewCard");
            form.validate({
               //ignore: ":not(:visible)",
                errorElement: 'span',
                errorClass: 'help-block',
                rules: {
                    cardnumber: {
                        required: true,
                    },
                    cardholdername: {
                        required: true,
                    },
                    validmonth: {
                        required: true,
                    },
                   validyear: {
                        required: true,
                    },
                    cvv: {
                        required: true,
                    },
                },
                messages: {
                   cardnumber: "Please Enter your card number",
                   cardholdername: "Please enter card holder name",
                   validmonth:"Please Enter valid month",
                  validyear: "Please Enter valid year",
                  cvv: "Please Enter your cvv number",
                }

            });
        });


/*========== TypeWriter  ========= */

(function ( $ ) {
 
    $.fn.typewriter = function( options ) {

        var settings = $.extend({
            text: $(this).attr("tw-text"),
            delay: 150,
            waitingTime: 1000,
            cursor: false,
            hide: 0,
        }, options );

        var item = $(this); //Our element
        var i = 0;          //Current char index

        //Function for adding char
        function startType() {
            //If cursor is enabled, we're adding our class.
            if (i==0 && settings.cursor==true) {
                item.addClass("tw-cursor");
            }
            //This is where the magic happens
            if (i<settings.text.length) {
                item.append(settings.text.charAt(i));
                i++;
                //Call function again
                setTimeout( startType, settings.delay );
            }
            //If the whole text appears, we're removing our class.
            else {
                item.removeClass("tw-cursor");
                //Hide element if it necessary.
                if (settings.hide>0) {
                    setTimeout( function() {
                        item.fadeOut();
                    }, settings.hide );
                }
            }
        }

        //Call our function for the first time.
        setTimeout( startType, settings.waitingTime );
        
    };
 
}( jQuery ));



      $(document).ready(function(){
        
        $("#typewriter_num").typewriter({
            text: "01 234 567 890",
            delay: 100,
            waitingTime: 1000,
            hide: false,
            cursor: false,
            
        });
    });