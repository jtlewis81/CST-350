$(function(){

    console.log("jQuery is ready");

    $("#get-songs-from-api").click(function(){
        console.log("get songs button clicked");

        $.ajax({
            dataType: "json",
            url: "getsongs.php",
            success: function(songs){
                console.log("Here is the list of songs from the server : ");
                console.log(songs);

                $.each(songs, function(i, song) {
                    var songstring = '<li>Title: ' + song.title + ' | Artist: ' + song.artist + '</li>';
                    $(songstring).appendTo('#songs').hide().fadeIn();
                })
            }
        })
    });

    $("#add-song").click(function(){
        var song = {
            artist: $('#artist').val(),
            title: $('#title').val()
        }
        
        $.ajax({
            type:'GET',
            url:'putsong.php',
            dataType: "json",
            data: song,
            success:function(newsong){
                console.log("Here is the song the server sent back:");
                console.log(newsong);
                var songstring = '<li>Title: ' + newsong.title + ' | Artist: ' + newsong.artist + '</li>';
                    $(songstring).appendTo('#songs').hide().fadeIn();
            }

        }) 
    })

});