#include "stdafx.h"
#include <cstdlib>
#include <string>
#include <iostream>

#define FLEN 512

int convert_to_hex(char c)
{
	char hexVal[3];
	sprintf_s(hexVal, "%02X", 0x69);

	if (strncmp(&c, hexVal, 2) == 1) {
		printf(">> %s ", hexVal); // indicate where it change (late)
		return c + 1;
	}
	return c;
}

int test_file_read_write() {
	char c;
	int i = 0;
	char fileName[128] = "bin_file.dat";

	char toWrite[][128] = { "0xAA", "0xAB", "0xAC", "0xAD", "0XAE", "0XCD", "0xCE" };
	FILE *fpw, *fp;

	errno_t err = fopen_s(&fpw, fileName, "wb");

	for (auto j = 0; j < sizeof toWrite / sizeof *toWrite; ++j) {
		fwrite(toWrite[j], sizeof (char), sizeof toWrite[j], fpw);
	}
	fclose(fpw);

	err = fopen_s(&fp, fileName, "rb");

	for (i = 0; i < FLEN; i++) {
		c = convert_to_hex(fgetc(fp));
		printf("%02x ", c);
	}
	printf("\n");
	fclose(fp);


	return 0;
}