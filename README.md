# EASY SAVE

repo : CESIProgSys-EasySave
Projet CESI A3 Programmation system november 2021

EASY SAVE is a logiciel that help user saving their data.

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

### Single run
Single run starts a single backup process.

### Sequential run
Sequential run starts all the backup processes one after the other.


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

## Execution unique
L'éxecution unique lance un unique processus de sauvegarde. 

### V1-console

### V2 - GUI

## Execution séquentielle 
L'éxecution séquentielle lance tous les processsus de sauvegardes à la suite les uns des autres.

### V1-console

### V2 - GUI

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
