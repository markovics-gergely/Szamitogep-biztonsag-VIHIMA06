CC=gcc
OBJ=CaffParser.o
OUT=CaffParser
CFLAGS=-I.

%.o: %.c
	$(CC) -c -o $@ $< $(CFLAGS)

${OUT}: ${OBJ}
	$(CC) -o ${OUT} $(OBJ)