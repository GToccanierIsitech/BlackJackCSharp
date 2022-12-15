# BlackJackCSharp

### Question
- ##### Transtypage

```C#
short s = 300;
byte b = (byte)s;
Console.WriteLine(b); // b = 44 ?
```

Lorsque la valeur de "s" est convertie en un "byte" elle dépasse la plage de valeurs maximale que ce dernier peut contenir. Dans ce cas, 300 est modulo 256, ce qui donne 44 (300 - 256).

- ##### Enum :
L'énumération (enum) est une structure de données en C# qui permet de déclarer une liste de constantes. Ces énumérations vous permettent de donner des noms significatifs à des valeurs constantes, ce qui peut rendre votre code plus lisible et plus facile à maintenir.

 sources : 
 - https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/builtin-types/enum
 - https://www.w3schools.com/cs/cs_enums.php
 - https://www.tutorialsteacher.com/csharp/csharp-enum

- ##### Tableau multiDimentionelle : 

- Expliquer la difference entre ces cyntaxes

```C#
int[,] Tableau = new int[1, 2]; 

int[][] Tableau2 = new int[3][];
```

Le premier tableau est un tableau à deux dimensions, ce qui signifie qu'il peut contenir un nombre fixe d'éléments organisés en lignes et en colonnes. Dans ce cas, le tableau a une ligne et deux colonnes, Il peux contenir 2 valeurs.

Le deuxième tableau est un Tableaux en escalier. Cela signifie que chaque élément du tableau est en fait un autre tableau. Les dimensions des tableaux enfants ne sont pas fixées, ce qui signifie qu'ils peuvent être redimensionnés indépendamment les uns des autres.

En résumé, le premier tableau est un tableau à deux dimensions de taille fixe, tandis que le deuxième tableau est un Tableaux en escalier de taille variable.

sources : https://learn.microsoft.com/fr-fr/dotnet/csharp/programming-guide/arrays/jagged-arrays

- Tenter de parcourir des tableaux multidimentionnels avec des boucles for

```C#
// Méthode 1
	// Déclaration des dimentions du tableau
	const int x = 2;
	const int y = 3;
	// Création du tableau a 'x' dimension
	int[,] Tableau = new int[x, y];

	// Affichage du tableau a 'x' dimension
	Console.WriteLine("Contenu tableau a " + x + " dimension");
	for ( int i = 0; i < x; i++) {
		for (int j = 0; j < y; j++)
		{
			Console.WriteLine("[" + i + ", " + j + "]");
			Console.WriteLine(Tableau[i, j]);
		}
	}
// Méthode 2
	// Création du tableau a 'x' dimension
	int[][] Tableau2 = new int[3][];
	Tableau2[0] = new int[] { 45, 2 };
	Tableau2[1] = new int[] { 34, 34, 4, 67 };
	Tableau2[2] = new int[] { 2 };
	// Affichage du tableau a escalier
	Console.WriteLine("Contenu tableau a deux dimension");
	for (int i = 0; i < Tableau2.Length; i++)
	{
		for (int j = 0; j < Tableau2[i].Length; j++)
		{
			Console.WriteLine("[" + i + ", " + j + "]");
			Console.WriteLine(Tableau2[i][j]);
		}
	}
```


- Que signifie le terme assembly

Un assembly est un fichier exécutable ou une bibliothèque de codes partagés en C#. Il peut contenir des fichiers de code source, des fichiers de ressources, des fichiers de métadonnées et d'autres éléments nécessaires à l'exécution d'une application C#

sources :
- https://learn.microsoft.com/fr-fr/dotnet/standard/assembly/
- https://fr.wikipedia.org/wiki/Assembly_(informatique)
- https://www.developpez.net/forums/d929609/dotnet/general-dotnet/debuter/assembly-c-quoi/

- Citez un exemple réel d'un usage pertinant du mot cle "private"
On peut mettre des vérification lors d'un get ou set par exemple, pour une class CompteBancaire, on peut vérifier le solde du compte avant de retirer de l'argent 

```c#
public class CompteBancaire {   
	private double solde;   
	private String numeroDeCompte;   
	private String propriétaire;

	
}
```



En utilisant le mot-clé `private` pour déclarer les propriétés de la classe CompteBancaire, on peut s'assurer que ces propriétés ne seront pas modifiées ou lues directement depuis l'extérieur de la classe, ce qui peut aider à garantir la sécurité des données et la fiabilité de l'application.
