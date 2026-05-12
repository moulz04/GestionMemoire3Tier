-- Script de création de la base de données et de la table pour le projet GestionMemoire
-- À exécuter dans MySQL (par exemple via phpMyAdmin ou MySQL Workbench)

CREATE DATABASE IF NOT EXISTS bdmemoiregrp1;
USE bdmemoiregrp1;

CREATE TABLE IF NOT EXISTS Memoires (
    IDMemoire INT AUTO_INCREMENT PRIMARY KEY,
    SujetMemoire VARCHAR(2000) NOT NULL,
    DescriptionMemoire MEDIUMTEXT NOT NULL,
    AnneeMemoire INT NOT NULL
);

-- Insertion d'un exemple pour test (optionnel)
-- INSERT INTO Memoires (SujetMemoire, DescriptionMemoire, AnneeMemoire) VALUES ('Sujet de test', 'Description de test', 2024);
