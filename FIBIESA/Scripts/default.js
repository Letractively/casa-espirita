function WinOpen(url, nome, altura, largura) {
    w = screen.width;
    h = screen.height;

    meio_w = w / 2;
    meio_h = h / 2;

    altura2 = altura / 2;
    largura2 = largura / 2;
    meio1 = meio_h - altura2;
    meio2 = meio_w - largura2;

    var windowRef = window.open(url, nome, "toolbar=no,directories=no,location=no,menubar=no,height=" + altura + "px,width=" + largura + "px,top=" + meio1 + "px,left=" + meio2 + "px");
    windowRef.focus();
}

function formatar(src, mask, e) {
    var i = src.value.length;
    var saida = mask.substring(0, 1);
    var texto = mask.substring(i);

    var Key = '';
    var strCheck = '0123456789';

    if (navigator.appName == "Microsoft Internet Explorer")
        var whichCode = e.keyCode;
    else
        var whichCode = e.which;

    if ((whichCode == 13) || (whichCode == 8) || (whichCode == 0))
        return true;

    key = String.fromCharCode(whichCode);

    if (strCheck.indexOf(key) == -1)
        return false;

    if (src.value.length < mask.length) {
        if (texto.substring(0, 1) != saida) {
            src.value += texto.substring(0, 1);
            return true;
        }
    }
    else {
        return false;
    }
}

function Inteiros(src, e) {
    for (var i = 0; i < src.value.length; i++) {
        if (src.value.charAt(i) >= 0 && src.value.charAt(i) <= 9) {
            src.value = src.value.substr(0, src.value.length);
        } else {
            src.value = src.value.substr(0, (src.value.length - 1));
        }
    }

}

function Reais(src, e) {
    var Key = '';
    var strCheck = '0123456789.,';
    var whichCode = (window.Event) ? e.which : e.keyCode;

    if ((whichCode == 13) || (whichCode == 8) || (whichCode == 0))
        return true;

    key = String.fromCharCode(whichCode);

    if (strCheck.indexOf(key) == -1)
        return false;  // Chave inválida
    else
        return true;

}

function Real(evt) {
    var e = evt ? evt : window.event;
    if (!e)
        return;

    var key = 0;

    if (e.keyCode) {
        key = e.keyCode;
    }
    else {
        if (typeof (e.which) != 'undefined') {
            key = e.which;
        }
    }

    if (key == 44) //virgula = 44 ponto = 46 
        return true;

    if (key > 47 && key < 58) // numeros de 0 a 9 
        return true;
    else if ((key == 8) || (key == 9)) // backspace e tab
        return true;
    else {
        return false;
    }
}

function mascara(objeto, padrao) {
    if (objeto.value.lenght > padrao.length) {
        objeto.value.substr(0, padrao.length);
    }
    for (var i = 0; i < objeto.value.length; i++) {
        if ((padrao.charAt(i) == "0") && !(objeto.value.charAt(i) >= 0 && objeto.value.charAt(i) <= 9)) {
            objeto.value = objeto.value.substr(0, i);
        }
    }
    var char = padrao.charAt(i);
    if ((char != "0") && (char != "#")) {
        objeto.value = objeto.value + char;
    }
    var charini = padrao.charAt(0);
    if ((charini != "0") && (charini != "#")) {
        if (objeto.value.substr(0, 1) != charini) {
            objeto.value = charini + objeto.value;
        }
    }
}

// Formata o campo valor monetário
function formataValor(campo, evt) {
    //1.000.000,00
    var xPos = PosicaoCursor(campo);
    evt = getEvent(evt);
    var tecla = getKeyCode(evt);
    if (!teclaValida(tecla))
        return;

    vr = campo.value = filtraNumeros(filtraCampo(campo));
    if (vr.length > 0) {
        vr = parseFloat(vr.toString()).toString();
        tam = vr.length;

        if (tam == 1)
            campo.value = "0,0" + vr;
        if (tam == 2)
            campo.value = "0," + vr;
        if ((tam > 2) && (tam <= 5)) {
            campo.value = vr.substr(0, tam - 2) + ',' + vr.substr(tam - 2, tam);
        }
        if ((tam >= 6) && (tam <= 8)) {
            campo.value = vr.substr(0, tam - 5) + '.' + vr.substr(tam - 5, 3) + ',' +
vr.substr(tam - 2, tam);
        }
        if ((tam >= 9) && (tam <= 11)) {
            campo.value = vr.substr(0, tam - 8) + '.' + vr.substr(tam - 8, 3) + '.' +
vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2, tam);
        }
        if ((tam >= 12) && (tam <= 14)) {
            campo.value = vr.substr(0, tam - 11) + '.' + vr.substr(tam - 11, 3) + '.' +
vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3) + ',' + vr.substr(tam - 2,
tam);
        }
        if ((tam >= 15) && (tam <= 18)) {
            campo.value = vr.substr(0, tam - 14) + '.' + vr.substr(tam - 14, 3) + '.' +
vr.substr(tam - 11, 3) + '.' + vr.substr(tam - 8, 3) + '.' + vr.substr(tam - 5, 3)
+ ',' + vr.substr(tam - 2, tam);
        }
    }
    MovimentaCursor(campo, xPos);
}
