# Exercice Bank en C#

## Énoncé

### 1. Classe `Person`

Créer une classe `Person` implémentant :

- **Propriétés publiques** :
  - `string FirstName`
  - `string LastName`
  - `DateTime BirthDate`

---

### 2. Classe `CurrentAccount`

Créer une classe `CurrentAccount` qui permet la gestion d’un compte courant, implémentant :

- **Propriétés publiques** :
  - `string Number`
  - `double Balance` (lecture seule)
  - `double CreditLine`
  - `Person Owner`

- **Méthodes publiques** :
  - `void Withdraw(double amount)`
  - `void Deposit(double amount)`

---

### 3. Classe `Bank`

Créer une classe `Bank` pour gérer les comptes de la banque, implémentant :

- **Propriétés** :
  - `Dictionary<string, CurrentAccount> Accounts` (lecture seule)
  - `string Name`

- **Méthodes** :
  - `void AddAccount(CurrentAccount account)`
  - `void DeleteAccount(string number)`

---

### 4. Méthode pour retourner le solde

Ajouter une méthode qui retourne le solde d’un compte courant.

---

### 5. Somme des comptes

Permettre à la banque de donner la somme de tous les comptes d’une personne.
