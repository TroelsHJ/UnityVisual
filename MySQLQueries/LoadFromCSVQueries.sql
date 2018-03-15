LOAD DATA LOCAL INFILE 'C:\\Users\\Troels Jensen\\Desktop\\UnityVisual\\Data\\selvskaber.csv' 
INTO TABLE selvskaber
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\r\n'
IGNORE 1 LINES;

LOAD DATA LOCAL INFILE 'C:\\Users\\Troels Jensen\\Desktop\\UnityVisual\\Data\\afdelinger.csv' 
INTO TABLE afdelinger
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\r\n'
IGNORE 1 LINES;

LOAD DATA LOCAL INFILE 'C:\\Users\\Troels Jensen\\Desktop\\UnityVisual\\Data\\ventelister.csv' 
INTO TABLE ventelister
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\r\n'
IGNORE 1 LINES;