<?php
    $song1 = array ('id'=>1, 'artist'=>'ABBA', 'title'=>'Dancing Queen');
    $song2 = array ('id'=>2, 'artist'=>'Queen', 'title'=>'Bohemian Rhapsody');
    $song3 = array ('id'=>3, 'artist'=>'Elvis', 'title'=>'Hound Dog');
    $song4 = array ('id'=>4, 'artist'=>'Sinatra', 'title'=>'Fly me to the Moon');
    $song5 = array ('id'=>5, 'artist'=>'Beatles', 'title'=>'Hey Jude');

    $arr_list = [ $song1, $song2, $song3, $song4, $song5 ];

    header('Content-Type: application/json');
    echo json_encode($arr_list);
?>