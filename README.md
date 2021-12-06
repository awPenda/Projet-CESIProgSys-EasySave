# EASY SAVE

repo : CESIProgSys-EasySave
Projet CESI A3 Programmation system november 2021

EASY SAVE is a logiciel that help user saving their data.

Liv 1 :
https://viacesifr-my.sharepoint.com/:w:/g/personal/amelie_willems_viacesi_fr/Eb3LgEMi7qFIpZjNY4xcWhcBRiODLB3UVwRHmdjZlXBjuQ?e=W9nEs2

----


# User Guide

## V1-console

User is guided through all the processes. You just have to follow the commands printed in the console.

### Create a Savework
When you will create a SaveWork, the program are going to ask you : 
  a name, to identify your SaveWork
  a source directory, where the program will copy the files 
  a target directory, where the program will paste the files
  a type of save, complete or differential


### Single run
Single run starts a single save process.
When you will start a single run, you will have to specified the number of the SaveWork you want to proceed.

### Sequential run
Sequential run starts all the backup processes one after the other.
For a sequential run, the program will run each SaveWork one after the other, you dont have to worry about it the program  will inform you if there's any issue.


## V2 - GUI

### Add a save work 

![image](https://user-images.githubusercontent.com/56393986/144767292-17092604-cbfb-40f6-9e53-59cb1b869d0b.png)

### Run a save wok

![image](https://user-images.githubusercontent.com/56393986/144767300-261335cc-72b0-4252-9010-36ffd98c35ab.png)

#### Single run
Single run starts a single backup process.

#### Sequential run
Sequential run starts all the backup processes one after the other.

### Settings 

![image](https://user-images.githubusercontent.com/56393986/144767306-d124222a-9ddb-46b3-a6fd-74b7806d71e6.png)


## about logs and state files

The LogFile and the stateFile will be updated and save in real time, and each time a save function is called. 

log file structure :
``` 
{
  "name":"",
  "sourceFile":"",
  "targetFile":"",
  "fileSize":"",
  "fileTransferTimee":"",
  "time":""
  
}
```
state file structure :
```
{
  "name":"",
  "state":"",
  "sourceFile":"",
  "targetFile":"",
  "totalFileNb":"",
  "totalFileSize":"",
  "progress":"", 
  "nbFilesLeft":"",
  "sizeFileLeft":"",
  "time":""
}
```






----


# Guide utilisateur 

### V1-console


#### Create a Savework
Lorsque vous créerez un travail de sauvegarde, le programme va vous demander :
   un nom, pour identifier votre travail de sauvegarde
   un répertoire source, où le programme copiera les fichiers
   un répertoire cible, où le programme collera les fichiers
   un type de sauvegarde, complète ou différentielle

#### Lancement unique
L'éxecution unique lance un unique processus de sauvegarde. 
Lorsque vous démarrerez une seule analyse, vous devrez spécifier le numéro du travail de sauvegarde que vous souhaitez effectuer.

#### Lancement séquentiel
L'éxecution séquentielle lance tous les processsus de sauvegardes à la suite les uns des autres.
Pour une exécution séquentielle, le programme exécutera chaque travail de sauvegarde l'un après l'autre, vous n'avez pas à vous en soucier, le programme vous informera en cas de problème.


## V2 - GUI

### Ajouter un travail de sauvegarde

![image](https://user-images.githubusercontent.com/56393986/144767604-588767a2-93ca-414a-84aa-7d6824829c94.png)

### Executer un travail de sauvegarde

![image](https://user-images.githubusercontent.com/56393986/144767594-f0d555fc-184f-4407-ad63-fea3688ffe18.png)

#### Lancement unique
L'éxecution unique lance un unique processus de sauvegarde. 

#### Lancement séquentiel
L'éxecution séquentielle lance tous les processsus de sauvegardes à la suite les uns des autres.

### Paramètres 

![image](https://user-images.githubusercontent.com/56393986/144767577-939f33fb-de84-4328-90c2-07663b5fbf63.png)



## À propos des fichiers logs et d'état
L'historique des executions est sauvegardé dans un fichier log journalier ainsi que l'état des sauvegardes. 

structure fichier log :
```
{
  "name":"",
  "sourceFile":"",
  "targetFile":"",
  "fileSize":"",
  "fileTransferTimee":"",
  "time":""
  
}
```
structure fichier état :
```
{
  "name":"",
  "state":"",
  "sourceFile":"",
  "targetFile":"",
  "totalFileNb":"",
  "totalFileSize":"",
  "progress":"", 
  "nbFilesLeft":"",
  "sizeFileLeft":"",
  "time":""
}
```
