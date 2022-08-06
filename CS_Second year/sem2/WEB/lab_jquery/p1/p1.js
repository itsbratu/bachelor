/// <reference path="typings/globals/jquery/index.d.ts" />
let animale = $("#animale")
let masini = $("#masini")

function move(el){
    let x = $(el);
    if (animale.has(x).length != 0)
        x.appendTo("#masini");
    else
        x.appendTo("#animale");
}



