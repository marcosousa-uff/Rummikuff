from Carta import Carta
class Baralho:
    cartas = []

    def __init__(self):
        self.cartas = self.gerarCartas()

    def gerarCartas(self):
        for i in range(0,4):
            if i == 0:
                cor = 'azul'
            elif i == 1:
                cor = 'amarelo'
            elif i == 2:
                cor = 'preto'
            else:
                cor = 'vermelho'
            for j in range(0,2):
                for valor in range(1,14):
                    self.cartas.append(Carta(valor,cor,1))
