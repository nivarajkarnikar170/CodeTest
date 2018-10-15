window.onload = function () {
    document.getElementById("player1").play();

    document.getElementById("btnPlayAudio").addEventListener("click", function () {
        document.getElementById("player2").play();
    });
}

