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