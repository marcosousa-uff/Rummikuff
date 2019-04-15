class Carta(object):
    def __init__(self,cor,numero,visivel):
        self.cor = cor
        self.numero = numero
        self.visivel = visivel

        pass
    
    def virarCarta():
        if self.visivel == 0:
            self.visivel = 1
            self.img = "img/Cartas/"+str(cor)+"/"+str(numero)+".png"
        else:
            self.visivel = 0
            self.img = "img/Cartas/cartaVirada.png"

    pass