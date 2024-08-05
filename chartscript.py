import numpy as np
import matplotlib.pyplot as plt

def my_function():
    x = np.linspace(-10, 10, 1000)
    myFunction = x** 3 + 2* x -6
    
    plt.subplot(211)
    plt.plot(x,myFunction, 'g-')

    plt.subplot(212)
    parties =['Ludzie', 'Elfy', 'Krasnoludy', 'Enty']
    result = [21.56, 19.22, 28.12, 30.10]
    plt.bar(parties,result)
    plt.show()

