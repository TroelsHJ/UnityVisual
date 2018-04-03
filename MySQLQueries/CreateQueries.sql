CREATE TABLE selvskaber (
    SelId INT NOT NULL PRIMARY KEY,
    SelName VARCHAR(40) NOT NULL,
    SelTlf INT NOT NULL,
    SelEmail varchar(60) NOT NULL
);

CREATE TABLE afdelinger (
    AfdId INT NOT NULL PRIMARY KEY,
    FK_SelId INT NOT NULL, 
    AfdName varchar(100) NOT NULL, 
    AfdPostBy INT NOT NULL, 
    FOREIGN KEY (FK_SelId) references selvskaber (SelId)
);

CREATE TABLE ventelister (
    FK_AfdId INT NOT NULL, 
    FK_SelId INT NOT NULL, 
    Lejemaalstype varchar(60) NOT NULL, 
    Lejlighedstype varchar(60) NOT NULL, 
    Rum INT NOT NULL, 
    AntalPaaVenteliste INT NOT NULL, 
	ListeId INT NOT NULL PRIMARY KEY auto_increment,
    FOREIGN KEY (FK_AfdId) references afdelinger (AfdId),
    FOREIGN KEY (FK_SelId) references selvskaber (SelId)
);

CREATE TABLE omraadenavn (
AfdId INT NOT NULL, 
Navn varchar(60) NOT NULL PRIMARY KEY
);