Para iniciar o mongoDb na pasta padrão do mongoDB (\Data\Db):
	mongod

Para iniciar o mongoDb em outra pasta:
	mongod.exe --dbpath c:\db_MongoDB

Ccriar arquivo mongod.conf na pasta bin do mongoDB com o seguinte conteúdo:
	dbpath = c:/data/db
	logpath = c:/mongodb2.4.0/logs/mongo.log log
	logappend = true 

Para criar o serviço no windows:
	mongod.exe --config "c:\mongodb2.4.0\bin\mongod.conf" --install