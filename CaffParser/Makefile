CC = gcc
SRC = CaffParser.c
OUT = CaffParser.dll
OBJ = CaffParser.o
INC= -I include

CaffParser:
	$(CC) $(SRC) -o CaffParser

CaffParser.dll: CaffParser.o
	$(CC) -shared -o $(OUT) $(OBJ) 

CaffParser.o: $(SRC) 
	$(CC) $(INC) -DBDLL -c $(SRC) -o $(OBJ)