
let searchBox = document.querySelector('#searchBox');
let movDetails = document.querySelector('#movieDetails');
let detPanel = document.querySelector('#detailPanel');
let movieStartTimer;

//alert(Today);

if(detPanel != null){
    movieStartTimer = setInterval(StartMovie, 10000);
}

if(movDetails != null){
    $('#movieDetails').animate({top: 0},700,'swing');
}

function StartMovie(){
    $('#detailPanel').animate({top: 750},420, 'swing');
}

function ClosePanel(){
    $('#movieDetails').animate({top: -1000},700,'swing');
}

