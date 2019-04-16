
from Baralho import Baralho


if __name__ == "__main__":
    baralho = Baralho()

    for carta in Baralho.cartas:
        print(carta.valor,carta.cor)
