#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#include <math.h>

#define ARG_ERROR 1
#define FILE_ERROR 2
#define PARSE_ERROR 3

char *caff_name;
char *rootPath = "../caff_files/";
char *outPath = "../caff_out/";
int current_pos = 0;
int max_pos;
int num_of_ciffs;
const int bytesPerPixel = 3;

unsigned char *createBitmapFileHeader(int height, int stride)
{
   int fileSize = 54 + (stride * height);
   static unsigned char fileHeader[] = {
       0, 0,       /// signature
       0, 0, 0, 0, /// image file size in bytes
       0, 0, 0, 0, /// reserved
       0, 0, 0, 0, /// start of pixel array
   };
   fileHeader[0] = (unsigned char)('B');
   fileHeader[1] = (unsigned char)('M');
   fileHeader[2] = (unsigned char)(fileSize);
   fileHeader[3] = (unsigned char)(fileSize >> 8);
   fileHeader[4] = (unsigned char)(fileSize >> 16);
   fileHeader[5] = (unsigned char)(fileSize >> 24);
   fileHeader[10] = (unsigned char)(54);
   return fileHeader;
}

unsigned char *createBitmapInfoHeader(int height, int width)
{
   static unsigned char infoHeader[] = {
       0, 0, 0, 0, /// header size
       0, 0, 0, 0, /// image width
       0, 0, 0, 0, /// image height
       0, 0,       /// number of color planes
       0, 0,       /// bits per pixel
       0, 0, 0, 0, /// compression
       0, 0, 0, 0, /// image size
       0, 0, 0, 0, /// horizontal resolution
       0, 0, 0, 0, /// vertical resolution
       0, 0, 0, 0, /// colors in color table
       0, 0, 0, 0, /// important color count
   };
   infoHeader[0] = (unsigned char)(40);
   infoHeader[4] = (unsigned char)(width);
   infoHeader[5] = (unsigned char)(width >> 8);
   infoHeader[6] = (unsigned char)(width >> 16);
   infoHeader[7] = (unsigned char)(width >> 24);
   infoHeader[8] = (unsigned char)(height);
   infoHeader[9] = (unsigned char)(height >> 8);
   infoHeader[10] = (unsigned char)(height >> 16);
   infoHeader[11] = (unsigned char)(height >> 24);
   infoHeader[12] = (unsigned char)(1);
   infoHeader[14] = (unsigned char)(3 * 8);
   return infoHeader;
}

void generateBitmapImage(int height, int width, unsigned char* image, char *imageFileName)
{
   int widthInBytes = width * bytesPerPixel;
   unsigned char padding[3] = {0, 0, 0};
   int paddingSize = (4 - (widthInBytes) % 4) % 4;
   int stride = (widthInBytes) + paddingSize;
   FILE *imageFile = fopen(imageFileName, "wb");
   unsigned char *fileHeader = createBitmapFileHeader(height, stride);
   fwrite(fileHeader, 1, 14, imageFile);
   unsigned char *infoHeader = createBitmapInfoHeader(height, width);
   fwrite(infoHeader, 1, 40, imageFile);

   // In BMP the 0,0 coordinate is at the bottom left, meaning we have to invert the y axis data from the CAFF file.
   // Also instead of RGB, bmp uses BGR color definitions, hence the order swapping of the pixel color data.
   unsigned char pixelLine[widthInBytes];
   for (int i = 0; i < height; i++) {
      for (int j = 0; j < width; j++) {
         int x = j;
         int y = height - (i + 1);
         pixelLine[x * 3] = image[y * widthInBytes + x * bytesPerPixel + 2];
         pixelLine[x * 3 + 1] = image[y * widthInBytes + x * bytesPerPixel + 1];
         pixelLine[x * 3 + 2] = image[y * widthInBytes + x * bytesPerPixel];
      }
      fwrite(pixelLine, 1, widthInBytes, imageFile);
      fwrite(padding, 1, paddingSize, imageFile);
   }
   fclose(imageFile);
}

int getIntFromArray(unsigned char *array, int size)
{
   int iter = 0;
   for (int i = 0; i < size; i++)
   {
      iter += array[i] << i * 8;
   }
   return iter;
}

int readBytesToInt(FILE *file, int size)
{
   unsigned char num_arr[size];
   fread(num_arr, size, 1, file);
   current_pos += size;
   fseek(file, current_pos, SEEK_SET);
   return getIntFromArray(num_arr, size);
}

void readBytesToCharArray(FILE *file, char *char_arr, int size)
{
   fread(char_arr, size, 1, file);
   char_arr[size] = '\0';
   current_pos += size;
   fseek(file, current_pos, SEEK_SET);
}

int readCaffHeaderBlock(FILE *file, int blocklen)
{
   unsigned char magic[4 + 1];
   readBytesToCharArray(file, magic, 4);
   if (magic[0] != 'C' || magic[1] != 'A' || magic[2] != 'F' || magic[3] != 'F')
   {
      printf("Invalid CAFF magic!\n");
      return PARSE_ERROR;
   }

   int length = readBytesToInt(file, 8);
   if (length != blocklen)
   {
      printf("Invalid header block length!\n");
      return PARSE_ERROR;
   }

   num_of_ciffs = readBytesToInt(file, 8);
   return 0;
}

void writeToCaffMeta(char *creator, char *date)
{
   char metapath[strlen(outPath) + strlen(caff_name) + strlen("_caff_meta.txt")];
   sprintf(metapath, "%s%s_caff_meta.txt", outPath, caff_name);
   FILE *meta = fopen(metapath, "wb");

   fprintf(meta, "Creator=");
   fprintf(meta, creator);
   fprintf(meta, "\n");
   fprintf(meta, "Date=");
   fprintf(meta, date);
   fprintf(meta, "\n");

   fclose(meta);
}

void writeToCiffMeta(int id, int id_length, char *duration, char *caption, char *tags)
{
   char metapath[strlen(outPath) + strlen(caff_name) + 1 + id_length + strlen("_ciff_meta.txt")];
   sprintf(metapath, "%s%s_%d_ciff_meta.txt", outPath, caff_name, id);
   FILE *meta = fopen(metapath, "wb");

   fprintf(meta, "Duration=");
   fprintf(meta, duration);
   fprintf(meta, "\n");
   fprintf(meta, "Caption=");
   fprintf(meta, caption);
   fprintf(meta, "\n");
   fprintf(meta, "Tags=");
   fprintf(meta, tags);
   fprintf(meta, "\n");

   fclose(meta);
}

int readCaffCreditsBlock(FILE *file, int blocklen)
{
   int year = readBytesToInt(file, 2);

   unsigned char date_arr[4];
   fread(date_arr, 4, 1, file);
   current_pos += 4;
   fseek(file, current_pos, SEEK_SET);

   char date[16 + 1];
   sprintf(date, "%04d-%02d-%02d %02d:%02d\0", year, date_arr[0], date_arr[1], date_arr[2], date_arr[3]);

   int creator_length = readBytesToInt(file, 8);
   char creator[creator_length + 1];
   readBytesToCharArray(file, creator, creator_length);

   if (6 + 8 + creator_length != blocklen)
   {
      printf("Invalid credits block length!\n");
      return PARSE_ERROR;
   }
   writeToCaffMeta(creator, date);
   return 0;
}

int readCaffAnimationBlock(FILE *file, int blocklen, int actual_ciff)
{
   int duration = readBytesToInt(file, 8);
   int dur_length = (duration == 0 ? 1 : (int)(log10(duration) + 1));
   char dur_char[dur_length + 1];
   sprintf(dur_char, "%d\0", duration);

   unsigned char magic[4 + 1];
   readBytesToCharArray(file, magic, 4);
   if (magic[0] != 'C' || magic[1] != 'I' || magic[2] != 'F' || magic[3] != 'F')
   {
      printf("Invalid CIFF magic!\n");
      return PARSE_ERROR;
   }

   int header_size = readBytesToInt(file, 8);

   int content_size = readBytesToInt(file, 8);
   int width = readBytesToInt(file, 8);
   int height = readBytesToInt(file, 8);

   if (content_size != width * height * bytesPerPixel)
   {
      printf("Invalid CIFF content size!\n");
      return PARSE_ERROR;
   }

   if (8 + header_size + content_size != blocklen)
   {
      printf("Invalid animation block length!\n");
      return PARSE_ERROR;
   }

   int remaining = header_size - (4 + 8 + 8 + 8 + 8);
   char capTags[remaining];
   readBytesToCharArray(file, capTags, remaining);

   char *tags;
   tags = strchr(capTags, '\n') + 1;

   int caption_length = (int)(tags - capTags);
   if (caption_length <= 1)
   {
      printf("There is no caption!\n");
      return PARSE_ERROR;
   }
   char caption[caption_length];
   memcpy(caption, capTags, caption_length - 1);

   for (int i = 0; i < remaining - caption_length - 1; i++)
   {
      if (tags[i] == '\0')
         tags[i] = ',';
   }

   unsigned char rawContent[content_size];
   fread(rawContent, 1, content_size, file);
   current_pos += content_size;
   fseek(file, current_pos, SEEK_SET);

   int id_length = (actual_ciff == 0 ? 1 : (int)(log10(actual_ciff) + 1));
   char filename[strlen(outPath) + strlen(caff_name) + 1 + id_length + strlen(".bmp")];
   sprintf(filename, "%s%s_%d.bmp", outPath, caff_name, actual_ciff);

   writeToCiffMeta(actual_ciff, id_length, dur_char, caption, tags);

   generateBitmapImage(height, width, rawContent, filename);

   return 0;
}

int readCaffBlock(FILE *file)
{
   bool headerRead = false;
   bool creditsRead = false;

   int actual_ciff = 0;
   while (current_pos < max_pos)
   {
      unsigned char typeLength[9];
      fread(typeLength, 9, 1, file);
      current_pos += 9;
      fseek(file, current_pos, SEEK_SET);
      int type = (int)typeLength[0];
      int length = getIntFromArray(typeLength + 1, 8);

      int isError;
      switch (type)
      {
      case 1:
         isError = readCaffHeaderBlock(file, length);
         if (isError != 0)
            return isError;
         headerRead = true;
         break;
      case 2:
         if (!headerRead)
         {
            printf("Credits read before header block!\n");
            return PARSE_ERROR;
         }

         isError = readCaffCreditsBlock(file, length);
         if (isError != 0)
            return isError;
         creditsRead = true;
         break;
      case 3:
         if (!headerRead || !creditsRead)
         {
            printf("Animation read before header or credits block!\n");
            return PARSE_ERROR;
         }

         isError = readCaffAnimationBlock(file, length, actual_ciff++);
         if (isError != 0)
            return isError;
         break;
      default:
         printf("Invalid block type!\n");
         return PARSE_ERROR;
      }
   }
   if (current_pos != max_pos)
   {
      printf("Parse not over on end!\n");
      return PARSE_ERROR;
   }
   if (actual_ciff != num_of_ciffs)
   {
      printf("Parse not read all ciffs!\n");
      return PARSE_ERROR;
   }
   printf("Successfully parsed!\n");
   return 0;
}

int readCaff()
{
   FILE *file;

   int pathLength = strlen(rootPath) + strlen(caff_name) + strlen(".caff");
   char path[pathLength];
   sprintf(path, "%s%s.caff", rootPath, caff_name);
   file = fopen(path, "r");

   if (file == NULL)
   {
      printf("File not found");
      return FILE_ERROR;
   }

   fseek(file, 0, SEEK_END);
   max_pos = ftell(file);
   fseek(file, 0, SEEK_SET);

   current_pos = 0;
   int result = readCaffBlock(file);
   fclose(file);

   return result;
}

int main(int argc, char *argv[])
{
   if (argc == 2)
   {
      caff_name = malloc(sizeof(char) * (strlen(argv[1]) + 1));
      strcpy(caff_name, argv[1]);
      int result = readCaff();
      free(caff_name);
      return result;
   }
   else if (argc > 2)
   {
      printf("Too many arguments supplied.\n");
      return ARG_ERROR;
   }
   else
   {
      printf("File path argument expected.\n");
      return ARG_ERROR;
   }
}
