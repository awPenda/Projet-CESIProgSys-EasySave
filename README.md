# EASY SAVE

repo : CESIProgSys-EasySave
Projet CESI A3 Programmation system november 2021

EASY SAVE is a logiciel that help user saving their data.

----


# User Guide

## Single run
Single run starts a single backup process.

### V1-console

### V2 - GUI

## Sequential run
Sequential run starts all the backup processes one after the other.

### V1-console

### V2 - GUI

## about logs and state files

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
