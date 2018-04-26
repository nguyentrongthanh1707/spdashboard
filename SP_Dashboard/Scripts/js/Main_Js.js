/* * * * * * * * * * * * * * * * *
 * Pagination
 * javascript page navigation
 * * * * * * * * * * * * * * * * */
/*

var Pagination = {

    code: '',

    // --------------------
    // Utility
    // --------------------

    // converting initialize data
    Extend: function(data) {
        data = data || {};
        Pagination.size = data.size || 300;
        Pagination.page = data.page || 1;
        Pagination.step = data.step || 3;
    },

    // add pages by number (from [s] to [f])
    Add: function(s, f) {
        for (var i = s; i < f; i++) {
            Pagination.code += '<a>' + i + '</a>';
        }
    },

    // add last page with separator
    Last: function() {
        Pagination.code += '<i>...</i><a>' + Pagination.size + '</a>';
    },

    // add first page with separator
    First: function() {
        Pagination.code += '<a>1</a><i>...</i>';
    },



    // --------------------
    // Handlers
    // --------------------

    // change page
    Click: function() {
        Pagination.page = +this.innerHTML;
        Pagination.Start();
    },

    // previous page
    Prev: function() {
        Pagination.page--;
        if (Pagination.page < 1) {
            Pagination.page = 1;
        }
        Pagination.Start();
    },

    // next page
    Next: function() {
        Pagination.page++;
        if (Pagination.page > Pagination.size) {
            Pagination.page = Pagination.size;
        }
        Pagination.Start();
    },



    // --------------------
    // Script
    // --------------------

    // binding pages
    Bind: function() {
        var a = Pagination.e.getElementsByTagName('a');
        for (var i = 0; i < a.length; i++) {
            if (+a[i].innerHTML === Pagination.page) a[i].className = 'current';
            a[i].addEventListener('click', Pagination.Click, false);
        }
    },

    // write pagination
    Finish: function() {
        Pagination.e.innerHTML = Pagination.code;
        Pagination.code = '';
        Pagination.Bind();
    },

    // find pagination type
    Start: function() {
        if (Pagination.size < Pagination.step * 2 + 6) {
            Pagination.Add(1, Pagination.size + 1);
        }
        else if (Pagination.page < Pagination.step * 2 + 1) {
            Pagination.Add(1, Pagination.step * 2 + 4);
            Pagination.Last();
        }
        else if (Pagination.page > Pagination.size - Pagination.step * 2) {
            Pagination.First();
            Pagination.Add(Pagination.size - Pagination.step * 2 - 2, Pagination.size + 1);
        }
        else {
            Pagination.First();
            Pagination.Add(Pagination.page - Pagination.step, Pagination.page + Pagination.step + 1);
            Pagination.Last();
        }
        Pagination.Finish();
    },



    // --------------------
    // Initialization
    // --------------------

    // binding buttons
    Buttons: function(e) {
        var nav = e.getElementsByTagName('a');
        nav[0].addEventListener('click', Pagination.Prev, false);
        nav[1].addEventListener('click', Pagination.Next, false);
    },

    // create skeleton
    Create: function(e) {

        var html = [
            '<a>&#9668;</a>', // previous button
            '<span></span>',  // pagination container
            '<a>&#9658;</a>'  // next button
        ];

        e.innerHTML = html.join(' ');
        Pagination.e = e.getElementsByTagName('span')[0];
        Pagination.Buttons(e);
    },

    // init
    Init: function(e, data) {
        Pagination.Extend(data);
        Pagination.Create(e);
        Pagination.Start();
    }
};

*/


/* * * * * * * * * * * * * * * * *
* Initialization
* * * * * * * * * * * * * * * * */
/*

var init = function() {
    Pagination.Init(document.getElementById('pagination'), {
        size: 30, // pages size
        page: 1,  // selected page
        step: 3   // pages before and after current
    });
};

document.addEventListener('DOMContentLoaded', init, false);

*/
//
$(document).ready(function(){
    $('#checkbox1').change(function(){
        if(this.checked)
            $('#autoUpdate1').fadeIn('slow');
        else
            $('#autoUpdate1').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox2').change(function(){
        if(this.checked)
            $('#autoUpdate2').fadeIn('slow');
        else
            $('#autoUpdate2').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox3').change(function(){
        if(this.checked)
            $('#autoUpdate3').fadeIn('slow');
        else
            $('#autoUpdate3').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox4').change(function(){
        if(this.checked)
            $('#autoUpdate4').fadeIn('slow');
        else
            $('#autoUpdate4').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox5').change(function(){
        if(this.checked)
            $('#autoUpdate5').fadeIn('slow');
        else
            $('#autoUpdate5').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox6').change(function(){
        if(this.checked)
            $('#autoUpdate6').fadeIn('slow');
        else
            $('#autoUpdate6').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox7').change(function(){
        if(this.checked)
            $('#autoUpdate7').fadeIn('slow');
        else
            $('#autoUpdate7').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox8').change(function(){
        if(this.checked)
            $('#autoUpdate8').fadeIn('slow');
        else
            $('#autoUpdate8').fadeOut('slow');

    });
});


$(document).ready(function(){
    $('#checkbox9').change(function(){
        if(this.checked)
            $('#autoUpdate9').fadeIn('slow');
        else
            $('#autoUpdate9').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox10').change(function(){
        if(this.checked)
            $('#autoUpdate10').fadeIn('slow');
        else
            $('#autoUpdate10').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox11').change(function(){
        if(this.checked)
            $('#autoUpdate11').fadeIn('slow');
        else
            $('#autoUpdate11').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox12').change(function(){
        if(this.checked)
            $('#autoUpdate12').fadeIn('slow');
        else
            $('#autoUpdate12').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox13').change(function(){
        if(this.checked)
            $('#autoUpdate13').fadeIn('slow');
        else
            $('#autoUpdate13').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox14').change(function(){
        if(this.checked)
            $('#autoUpdate14').fadeIn('slow');
        else
            $('#autoUpdate14').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox15').change(function(){
        if(this.checked)
            $('#autoUpdate15').fadeIn('slow');
        else
            $('#autoUpdate15').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox16').change(function(){
        if(this.checked)
            $('#autoUpdate16').fadeIn('slow');
        else
            $('#autoUpdate16').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox17').change(function(){
        if(this.checked)
            $('#autoUpdate17').fadeIn('slow');
        else
            $('#autoUpdate17').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox18').change(function(){
        if(this.checked)
            $('#autoUpdate18').fadeIn('slow');
        else
            $('#autoUpdate18').fadeOut('slow');

    });
});

$(document).ready(function(){
    $('#checkbox19').change(function(){
        if(this.checked)
            $('#autoUpdate19').fadeIn('slow');
        else
            $('#autoUpdate19').fadeOut('slow');

    });
});