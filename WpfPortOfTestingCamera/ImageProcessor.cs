using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.IO;
using System.Diagnostics;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;

class ImageProcessor
{
    AForge.Point _TargetCenter;
    //string[] respostas;
    //Events
    public delegate void NewTargetPositionHandler(IntPoint Center, Bitmap image);

    public event NewTargetPositionHandler NewTargetPosition;
    public ImageProcessor()
    {
        _TargetCenter = new AForge.Point(0, 0);
    }

    public void Process(UnmanagedImage uimage)
    {
        Bitmap image = uimage.ToManagedImage();
        uimage = Grayscale.CommonAlgorithms.BT709.Apply(uimage);
        OtsuThreshold otsuThresholdFilter = new OtsuThreshold();
        otsuThresholdFilter.ApplyInPlace(uimage);
        DifferenceEdgeDetector edgeDetector = new DifferenceEdgeDetector();
        UnmanagedImage edgesImage = edgeDetector.Apply(uimage);
        BlobCounter blobCounter = new BlobCounter();
        blobCounter.FilterBlobs = true;
        blobCounter.MinWidth = 6;
        blobCounter.MinHeight = 6;
        blobCounter.MaxWidth = 30;
        blobCounter.MaxHeight = 150;
        blobCounter.ProcessImage(edgesImage);
        Blob[] blobs = blobCounter.GetObjectsInformation();
        Blob[] laterais = new Blob[2];
        Blob[] ordenado = new Blob[2];
        string[] letras_respostas = new string[10];
        Graphics g = Graphics.FromImage(image);
        Pen greenPen = new Pen(Color.Green, 2);
        Pen blackPen = new Pen(Color.Black, 2);
        Pen whitePen = new Pen(Color.White, 2);
        Pen penIn = new Pen(Color.Yellow, 2);
        int numero_codigo = 0;
        //apenas visualizacao dos quadrantes
        System.Drawing.Point[] arrumados = new System.Drawing.Point[8];
        System.Drawing.PointF[] quadro_codigo = new System.Drawing.PointF[4];
        System.Drawing.Point[] p1 = new System.Drawing.Point[4];
        System.Drawing.PointF[] tabela_codigo = new System.Drawing.PointF[112];
        System.Drawing.Point[] tabela_codigoa = new System.Drawing.Point[112];
        System.Drawing.PointF[] quadrado0 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado1 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado2 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado3 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado4 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado5 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado6 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado7 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado8 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado9 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado10 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado11 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado12 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado13 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado14 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado15 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado16 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado17 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado18 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado19 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado20 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado21 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado22 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado23 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado24 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado25 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado26 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado27 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado28 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado29 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado30 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado31 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado32 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado33 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado34 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado35 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado36 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado37 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado38 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado39 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado40 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado41 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado42 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado43 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado44 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado45 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado46 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado47 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado48 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado49 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado50 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado51 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado52 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado53 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado54 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado55 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado56 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado57 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado58 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado59 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado60 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado61 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado62 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado63 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado64 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado65 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado66 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado67 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado68 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado69 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado70 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado71 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado72 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado73 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado74 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado75 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado76 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado77 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado78 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado79 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado80 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado81 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado82 = new System.Drawing.PointF[4];
        System.Drawing.PointF[] quadrado83 = new System.Drawing.PointF[4];
        IntPoint Center = new IntPoint(0, 0);
        const int stepSize = 2;
        for (int i = 0, n = blobs.Length; i < n; i++)
        {
            List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
            List<IntPoint> corners = PointsCloud.FindQuadrilateralCorners(edgePoints);

            System.Drawing.Point[] crn = new System.Drawing.Point[4];
            for (int jj = 0; jj < corners.Count; jj++)
            {
                crn[jj] = new System.Drawing.Point(corners[jj].X, corners[jj].Y);
            }
            SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
            if (shapeChecker.IsQuadrilateral(edgePoints))
            {
                List<IntPoint> leftEdgePoints, rightEdgePoints;
                blobCounter.GetBlobsLeftAndRightEdges(blobs[i], out leftEdgePoints, out rightEdgePoints);
                List<IntPoint> leftEdgePoints1 = new List<IntPoint>();
                List<IntPoint> leftEdgePoints2 = new List<IntPoint>();
                List<IntPoint> rightEdgePoints1 = new List<IntPoint>();
                List<IntPoint> rightEdgePoints2 = new List<IntPoint>();
                int tx1, tx2, ty;
                int widthM1 = uimage.Width - 1;
                for (int k = 0; k < leftEdgePoints.Count; k++)
                {
                    tx1 = leftEdgePoints[k].X - stepSize;
                    tx2 = leftEdgePoints[k].X + stepSize;
                    ty = leftEdgePoints[k].Y;
                    leftEdgePoints1.Add(new IntPoint((tx1 < 0) ? 0 : tx1, ty));
                    leftEdgePoints2.Add(new IntPoint((tx2 > widthM1) ? widthM1 : tx2, ty));
                    tx1 = rightEdgePoints[k].X - stepSize;
                    tx2 = rightEdgePoints[k].X + stepSize;
                    ty = rightEdgePoints[k].Y;
                    rightEdgePoints1.Add(new IntPoint((tx1 < 0) ? 0 : tx1, ty));
                    rightEdgePoints2.Add(new IntPoint((tx2 > widthM1) ? widthM1 : tx2, ty));
                }
                byte[] leftValues1 = uimage.Collect8bppPixelValues(leftEdgePoints1);
                byte[] leftValues2 = uimage.Collect8bppPixelValues(leftEdgePoints2);
                byte[] rightValues1 = uimage.Collect8bppPixelValues(rightEdgePoints1);
                byte[] rightValues2 = uimage.Collect8bppPixelValues(rightEdgePoints2);
                float diff = 0;
                int pixelCount = 0;
                for (int k = 0; k < leftEdgePoints.Count; k++)
                {
                    if (rightEdgePoints[k].X - leftEdgePoints[k].X > stepSize * 2)
                    {
                        diff += (leftValues1[k] - leftValues2[k]);
                        diff += (rightValues2[k] - rightValues1[k]);
                        pixelCount += 2;
                    }
                }

                float diferenca = diff / pixelCount;
                if (diferenca > 120)
                {
                    if (blobs[i].Area > 225)
                    {
                        g.DrawPolygon(greenPen, crn);
                        laterais[numero_codigo] = new Blob(blobs[i]);
                        numero_codigo++;
                        if (numero_codigo > 1)
                        {
                            if (laterais[0].CenterOfGravity.X > laterais[1].CenterOfGravity.X)
                            {
                                ordenado[0] = laterais[1];
                                ordenado[1] = laterais[0];
                            }
                            else
                            {
                                ordenado[0] = laterais[0];
                                ordenado[1] = laterais[1];
                            }
                            g.DrawRectangle(blackPen, ordenado[0].Rectangle);
                            g.DrawRectangle(blackPen, ordenado[1].Rectangle);
                            AForge.Point reto0 = new AForge.Point(0, 0);
                            AForge.Point reto1 = new AForge.Point(0, 640);
                            System.Drawing.Point p10 = new System.Drawing.Point(ordenado[0].Rectangle.Right, ordenado[0].Rectangle.Top);
                            System.Drawing.Point p11 = new System.Drawing.Point(ordenado[1].Rectangle.Left, ordenado[1].Rectangle.Top);
                            System.Drawing.Point p12 = new System.Drawing.Point(ordenado[0].Rectangle.Right, ordenado[0].Rectangle.Bottom);
                            System.Drawing.Point p13 = new System.Drawing.Point(ordenado[1].Rectangle.Left, ordenado[1].Rectangle.Bottom);
                            AForge.Point ap10 = new AForge.Point(ordenado[0].Rectangle.Right, ordenado[0].Rectangle.Top);
                            AForge.Point ap11 = new AForge.Point(ordenado[1].Rectangle.Left, ordenado[1].Rectangle.Top);
                            AForge.Point ap12 = new AForge.Point(ordenado[0].Rectangle.Right, ordenado[0].Rectangle.Bottom);
                            AForge.Point ap13 = new AForge.Point(ordenado[1].Rectangle.Left, ordenado[1].Rectangle.Bottom);

                            int altura0 = ordenado[0].Rectangle.Height;
                            int altura1 = ordenado[1].Rectangle.Height;
                            int largura0 = ordenado[0].Rectangle.Width;
                            int largura1 = ordenado[1].Rectangle.Width;
                            float angulo0 = Line.FromPoints(ap10, ap11).GetAngleBetweenLines(Line.FromPoints(reto0, reto1));
                            float pontoX0 = ordenado[0].Rectangle.Right;
                            float pontoX1 = ordenado[1].Rectangle.Left;
                            float varX = ((pontoX1 - pontoX0 + 6) / 2); //ponto medio
                            float pontoY00 = ordenado[0].Rectangle.Top;
                            float pontoY01 = ordenado[0].Rectangle.Bottom;
                            float varY0 = ((pontoY01 - pontoY00-2) / 5);

                            float pontoY10 = ordenado[1].Rectangle.Top;
                            float pontoY11 = ordenado[1].Rectangle.Bottom;
                            float varY1 = ((pontoY11 - pontoY10-2) / 5);
                            float dif_pos0 = ((pontoY11 - pontoY01) / 2);
                            float dif_pos1 = ((pontoY01 - pontoY11) / 2);
                            float varY, varY2, var_menor;
                            if (varY1 > varY0)
                            {
                                varY = ((varY1 - varY0 - 1) / 16);// variacao do Y
                                varY2 = ((varY1 - varY0 - 1) / 12);// variacao do Y
                                var_menor = varY0;
                            }
                            else
                            {
                                varY = ((varY0 - varY1) / 16);
                                varY2 = ((varY0 - varY1) / 12);
                                var_menor = varY1;
                            }
                            
                            List<IntPoint> papel_branco = new List<IntPoint>();
                            List<IntPoint> quadro1 = new List<IntPoint>(), quadro2 = new List<IntPoint>(), quadro3 = new List<IntPoint>(), quadro4 = new List<IntPoint>(), quadro5 = new List<IntPoint>(), quadro6 = new List<IntPoint>(), quadro7 = new List<IntPoint>(), quadro8 = new List<IntPoint>(), quadro9 = new List<IntPoint>(), quadro10 = new List<IntPoint>(), quadro11 = new List<IntPoint>(), quadro12 = new List<IntPoint>(), quadro13 = new List<IntPoint>(), quadro14 = new List<IntPoint>(), quadro15 = new List<IntPoint>(), quadro16 = new List<IntPoint>(), quadro17 = new List<IntPoint>(), quadro18 = new List<IntPoint>(), quadro19 = new List<IntPoint>(), quadro20 = new List<IntPoint>(), quadro21 = new List<IntPoint>(), quadro22 = new List<IntPoint>(), quadro23 = new List<IntPoint>(), quadro24 = new List<IntPoint>(), quadro25 = new List<IntPoint>(), quadro26 = new List<IntPoint>(), quadro27 = new List<IntPoint>(), quadro28 = new List<IntPoint>(), quadro29 = new List<IntPoint>(), quadro30 = new List<IntPoint>(), quadro31 = new List<IntPoint>(), quadro32 = new List<IntPoint>(), quadro33 = new List<IntPoint>(), quadro34 = new List<IntPoint>(), quadro35 = new List<IntPoint>(), quadro36 = new List<IntPoint>(), quadro37 = new List<IntPoint>(), quadro38 = new List<IntPoint>(), quadro39 = new List<IntPoint>(), quadro40 = new List<IntPoint>(), quadro41 = new List<IntPoint>(), quadro42 = new List<IntPoint>(), quadro43 = new List<IntPoint>(), quadro44 = new List<IntPoint>(), quadro45 = new List<IntPoint>(), quadro46 = new List<IntPoint>(), quadro47 = new List<IntPoint>(), quadro48 = new List<IntPoint>(), quadro49 = new List<IntPoint>(), quadro50 = new List<IntPoint>(), quadro51 = new List<IntPoint>(), quadro52 = new List<IntPoint>(), quadro53 = new List<IntPoint>(), quadro54 = new List<IntPoint>(), quadro55 = new List<IntPoint>(), quadro56 = new List<IntPoint>(), quadro57 = new List<IntPoint>(), quadro58 = new List<IntPoint>(), quadro59 = new List<IntPoint>(), quadro60 = new List<IntPoint>(), quadro61 = new List<IntPoint>(), quadro62 = new List<IntPoint>(), quadro63 = new List<IntPoint>(), quadro64 = new List<IntPoint>(), quadro65 = new List<IntPoint>(), quadro66 = new List<IntPoint>(), quadro67 = new List<IntPoint>(), quadro68 = new List<IntPoint>();
                            System.Drawing.PointF[] tabela_respostas = new System.Drawing.PointF[80];
                            System.Drawing.PointF[][] quadrado_resposta = new System.Drawing.PointF[80][];
                            float tam_titulo = 0;

                           for (int linhas_resp = 0; linhas_resp < 6; linhas_resp++)
                            {
                                tam_titulo = 0;
                                for (int colunas_resp = 0; colunas_resp < 13; colunas_resp++)
                                {
                                    if (colunas_resp == 1 || colunas_resp == 7)
                                    {
                                        tam_titulo += ((varX + dif_pos1) / 30) - 2;
                                    }
                                    tabela_respostas[(linhas_resp * 13) + colunas_resp] = new System.Drawing.PointF((float)((pontoX0 + varX) + tam_titulo + (colunas_resp * ((varX + 3) / 14)) + (linhas_resp * dif_pos1 / 14) - Math.PI * 2 * (varY1 - varY0)), (float)(((pontoY00 + pontoY10) / 2) + ((linhas_resp *4)/5) + (linhas_resp * ((colunas_resp * ((varY1 - varY0) / 12) / 2) + varY0)) + ((colunas_resp * dif_pos0) / 12)));
                                }
                            }
                            for (int a0 = 0; a0 < 64; a0++)
                            {
                                quadrado_resposta[a0] = new System.Drawing.PointF[4];
                                quadrado_resposta[a0][0] = new System.Drawing.PointF(tabela_respostas[a0].X, tabela_respostas[a0].Y);
                                quadrado_resposta[a0][1] = new System.Drawing.PointF(tabela_respostas[(a0 + 1)].X, tabela_respostas[(a0 + 1)].Y);
                                quadrado_resposta[a0][2] = new System.Drawing.PointF(tabela_respostas[(a0 + 14)].X, tabela_respostas[(a0 + 14)].Y);
                                quadrado_resposta[a0][3] = new System.Drawing.PointF(tabela_respostas[(a0 + 13)].X, tabela_respostas[(a0 + 13)].Y);
                            }
                            for (int b0 = 0; b0 < 64; b0++)
                            {
                                if (b0 != 12 && b0 != 25 && b0 != 38 && b0 != 51)
                                    g.DrawPolygon(whitePen, quadrado_resposta[b0]);
                            }
                            List<IntPoint> resp_branco = new List<IntPoint>();
                            List<IntPoint> resp_quadros1 = new List<IntPoint>(), resp_quadros2 = new List<IntPoint>(), resp_quadros3 = new List<IntPoint>(), resp_quadros4 = new List<IntPoint>(), resp_quadros5 = new List<IntPoint>(), resp_quadros6 = new List<IntPoint>(), resp_quadros7 = new List<IntPoint>(), resp_quadros8 = new List<IntPoint>(), resp_quadros9 = new List<IntPoint>(), resp_quadros10 = new List<IntPoint>(), resp_quadros11 = new List<IntPoint>(), resp_quadros12 = new List<IntPoint>(), resp_quadros13 = new List<IntPoint>(), resp_quadros14 = new List<IntPoint>(), resp_quadros15 = new List<IntPoint>(), resp_quadros16 = new List<IntPoint>(), resp_quadros17 = new List<IntPoint>(), resp_quadros18 = new List<IntPoint>(), resp_quadros19 = new List<IntPoint>(), resp_quadros20 = new List<IntPoint>(), resp_quadros21 = new List<IntPoint>(), resp_quadros22 = new List<IntPoint>(), resp_quadros23 = new List<IntPoint>(), resp_quadros24 = new List<IntPoint>(), resp_quadros25 = new List<IntPoint>(), resp_quadros26 = new List<IntPoint>(), resp_quadros27 = new List<IntPoint>(), resp_quadros28 = new List<IntPoint>(), resp_quadros29 = new List<IntPoint>(), resp_quadros30 = new List<IntPoint>(), resp_quadros31 = new List<IntPoint>(), resp_quadros32 = new List<IntPoint>(), resp_quadros33 = new List<IntPoint>(), resp_quadros34 = new List<IntPoint>(), resp_quadros35 = new List<IntPoint>(), resp_quadros36 = new List<IntPoint>(), resp_quadros37 = new List<IntPoint>(), resp_quadros38 = new List<IntPoint>(), resp_quadros39 = new List<IntPoint>(), resp_quadros40 = new List<IntPoint>(), resp_quadros41 = new List<IntPoint>(), resp_quadros42 = new List<IntPoint>(), resp_quadros43 = new List<IntPoint>(), resp_quadros44 = new List<IntPoint>(), resp_quadros45 = new List<IntPoint>(), resp_quadros46 = new List<IntPoint>(), resp_quadros47 = new List<IntPoint>(), resp_quadros48 = new List<IntPoint>(), resp_quadros49 = new List<IntPoint>(), resp_quadros50 = new List<IntPoint>();
                                for (int resp_cols = 0; resp_cols < 7; resp_cols++)
                                {
                                    for (int resp_lins = 0; resp_lins < 11; resp_lins++)
                                    {
                                        resp_branco.Add(new IntPoint((int)((pontoX1) - 12 + resp_lins), (int)((pontoY10) + 4 + resp_cols)));
                                        resp_quadros1.Add(new IntPoint((int)(tabela_respostas[1].X + ((tabela_respostas[2].X - tabela_respostas[1].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[1].Y + ((tabela_respostas[14].Y - tabela_respostas[1].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros2.Add(new IntPoint((int)(tabela_respostas[2].X + ((tabela_respostas[3].X - tabela_respostas[2].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[2].Y + ((tabela_respostas[15].Y - tabela_respostas[2].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros3.Add(new IntPoint((int)(tabela_respostas[3].X + ((tabela_respostas[4].X - tabela_respostas[3].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[3].Y + ((tabela_respostas[16].Y - tabela_respostas[3].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros4.Add(new IntPoint((int)(tabela_respostas[4].X + ((tabela_respostas[5].X - tabela_respostas[4].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[4].Y + ((tabela_respostas[17].Y - tabela_respostas[4].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros5.Add(new IntPoint((int)(tabela_respostas[5].X + ((tabela_respostas[6].X - tabela_respostas[5].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[5].Y + ((tabela_respostas[18].Y - tabela_respostas[5].Y) / 2) - 2 + resp_cols)));

                                        resp_quadros6.Add(new IntPoint((int)(tabela_respostas[7].X + ((tabela_respostas[8].X - tabela_respostas[7].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[7].Y + ((tabela_respostas[20].Y - tabela_respostas[7].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros7.Add(new IntPoint((int)(tabela_respostas[8].X + ((tabela_respostas[9].X - tabela_respostas[8].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[8].Y + ((tabela_respostas[21].Y - tabela_respostas[8].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros8.Add(new IntPoint((int)(tabela_respostas[9].X + ((tabela_respostas[10].X - tabela_respostas[9].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[9].Y + ((tabela_respostas[22].Y - tabela_respostas[9].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros9.Add(new IntPoint((int)(tabela_respostas[10].X + ((tabela_respostas[11].X - tabela_respostas[10].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[10].Y + ((tabela_respostas[22].Y - tabela_respostas[10].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros10.Add(new IntPoint((int)(tabela_respostas[11].X + ((tabela_respostas[12].X - tabela_respostas[11].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[11].Y + ((tabela_respostas[23].Y - tabela_respostas[11].Y) / 2) - 2 + resp_cols)));


                                        resp_quadros11.Add(new IntPoint((int)(tabela_respostas[14].X + ((tabela_respostas[15].X - tabela_respostas[14].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[14].Y + ((tabela_respostas[26].Y - tabela_respostas[14].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros12.Add(new IntPoint((int)(tabela_respostas[15].X + ((tabela_respostas[16].X - tabela_respostas[15].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[15].Y + ((tabela_respostas[27].Y - tabela_respostas[15].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros13.Add(new IntPoint((int)(tabela_respostas[16].X + ((tabela_respostas[17].X - tabela_respostas[16].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[16].Y + ((tabela_respostas[28].Y - tabela_respostas[16].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros14.Add(new IntPoint((int)(tabela_respostas[17].X + ((tabela_respostas[18].X - tabela_respostas[17].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[17].Y + ((tabela_respostas[29].Y - tabela_respostas[17].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros15.Add(new IntPoint((int)(tabela_respostas[18].X + ((tabela_respostas[19].X - tabela_respostas[18].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[18].Y + ((tabela_respostas[30].Y - tabela_respostas[18].Y) / 2) - 2 + resp_cols)));

                                        resp_quadros16.Add(new IntPoint((int)(tabela_respostas[20].X + ((tabela_respostas[21].X - tabela_respostas[20].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[20].Y + ((tabela_respostas[32].Y - tabela_respostas[20].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros17.Add(new IntPoint((int)(tabela_respostas[21].X + ((tabela_respostas[22].X - tabela_respostas[21].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[21].Y + ((tabela_respostas[33].Y - tabela_respostas[21].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros18.Add(new IntPoint((int)(tabela_respostas[22].X + ((tabela_respostas[23].X - tabela_respostas[22].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[22].Y + ((tabela_respostas[34].Y - tabela_respostas[22].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros19.Add(new IntPoint((int)(tabela_respostas[23].X + ((tabela_respostas[24].X - tabela_respostas[23].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[23].Y + ((tabela_respostas[35].Y - tabela_respostas[23].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros20.Add(new IntPoint((int)(tabela_respostas[24].X + ((tabela_respostas[25].X - tabela_respostas[24].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[24].Y + ((tabela_respostas[36].Y - tabela_respostas[24].Y) / 2) - 2 + resp_cols)));


                                        resp_quadros21.Add(new IntPoint((int)(tabela_respostas[27].X + ((tabela_respostas[28].X - tabela_respostas[27].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[27].Y + ((tabela_respostas[39].Y - tabela_respostas[27].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros22.Add(new IntPoint((int)(tabela_respostas[28].X + ((tabela_respostas[29].X - tabela_respostas[28].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[28].Y + ((tabela_respostas[40].Y - tabela_respostas[28].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros23.Add(new IntPoint((int)(tabela_respostas[29].X + ((tabela_respostas[30].X - tabela_respostas[29].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[29].Y + ((tabela_respostas[41].Y - tabela_respostas[29].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros24.Add(new IntPoint((int)(tabela_respostas[30].X + ((tabela_respostas[31].X - tabela_respostas[30].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[30].Y + ((tabela_respostas[42].Y - tabela_respostas[30].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros25.Add(new IntPoint((int)(tabela_respostas[31].X + ((tabela_respostas[32].X - tabela_respostas[31].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[31].Y + ((tabela_respostas[43].Y - tabela_respostas[31].Y) / 2) - 2 + resp_cols)));

                                        resp_quadros26.Add(new IntPoint((int)(tabela_respostas[33].X + ((tabela_respostas[34].X - tabela_respostas[33].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[33].Y + ((tabela_respostas[45].Y - tabela_respostas[33].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros27.Add(new IntPoint((int)(tabela_respostas[34].X + ((tabela_respostas[35].X - tabela_respostas[34].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[34].Y + ((tabela_respostas[46].Y - tabela_respostas[34].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros28.Add(new IntPoint((int)(tabela_respostas[35].X + ((tabela_respostas[36].X - tabela_respostas[35].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[35].Y + ((tabela_respostas[47].Y - tabela_respostas[35].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros29.Add(new IntPoint((int)(tabela_respostas[36].X + ((tabela_respostas[37].X - tabela_respostas[36].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[36].Y + ((tabela_respostas[48].Y - tabela_respostas[36].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros30.Add(new IntPoint((int)(tabela_respostas[37].X + ((tabela_respostas[38].X - tabela_respostas[37].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[37].Y + ((tabela_respostas[49].Y - tabela_respostas[37].Y) / 2) - 2 + resp_cols)));


                                        resp_quadros31.Add(new IntPoint((int)(tabela_respostas[40].X + ((tabela_respostas[41].X - tabela_respostas[40].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[40].Y + ((tabela_respostas[52].Y - tabela_respostas[40].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros32.Add(new IntPoint((int)(tabela_respostas[41].X + ((tabela_respostas[42].X - tabela_respostas[41].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[41].Y + ((tabela_respostas[53].Y - tabela_respostas[41].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros33.Add(new IntPoint((int)(tabela_respostas[42].X + ((tabela_respostas[43].X - tabela_respostas[42].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[42].Y + ((tabela_respostas[54].Y - tabela_respostas[42].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros34.Add(new IntPoint((int)(tabela_respostas[43].X + ((tabela_respostas[44].X - tabela_respostas[43].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[43].Y + ((tabela_respostas[55].Y - tabela_respostas[43].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros35.Add(new IntPoint((int)(tabela_respostas[44].X + ((tabela_respostas[45].X - tabela_respostas[44].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[44].Y + ((tabela_respostas[56].Y - tabela_respostas[44].Y) / 2) - 2 + resp_cols)));

                                        resp_quadros36.Add(new IntPoint((int)(tabela_respostas[46].X + ((tabela_respostas[47].X - tabela_respostas[46].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[46].Y + ((tabela_respostas[58].Y - tabela_respostas[46].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros37.Add(new IntPoint((int)(tabela_respostas[47].X + ((tabela_respostas[48].X - tabela_respostas[47].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[47].Y + ((tabela_respostas[59].Y - tabela_respostas[47].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros38.Add(new IntPoint((int)(tabela_respostas[48].X + ((tabela_respostas[49].X - tabela_respostas[48].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[48].Y + ((tabela_respostas[60].Y - tabela_respostas[48].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros39.Add(new IntPoint((int)(tabela_respostas[49].X + ((tabela_respostas[50].X - tabela_respostas[49].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[49].Y + ((tabela_respostas[61].Y - tabela_respostas[49].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros40.Add(new IntPoint((int)(tabela_respostas[50].X + ((tabela_respostas[51].X - tabela_respostas[50].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[50].Y + ((tabela_respostas[62].Y - tabela_respostas[50].Y) / 2) - 2 + resp_cols)));


                                        resp_quadros41.Add(new IntPoint((int)(tabela_respostas[53].X + ((tabela_respostas[54].X - tabela_respostas[53].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[53].Y + ((tabela_respostas[65].Y - tabela_respostas[53].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros42.Add(new IntPoint((int)(tabela_respostas[54].X + ((tabela_respostas[55].X - tabela_respostas[54].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[54].Y + ((tabela_respostas[66].Y - tabela_respostas[54].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros43.Add(new IntPoint((int)(tabela_respostas[55].X + ((tabela_respostas[56].X - tabela_respostas[55].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[55].Y + ((tabela_respostas[67].Y - tabela_respostas[55].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros44.Add(new IntPoint((int)(tabela_respostas[56].X + ((tabela_respostas[57].X - tabela_respostas[56].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[56].Y + ((tabela_respostas[68].Y - tabela_respostas[56].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros45.Add(new IntPoint((int)(tabela_respostas[57].X + ((tabela_respostas[58].X - tabela_respostas[57].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[57].Y + ((tabela_respostas[69].Y - tabela_respostas[57].Y) / 2) - 2 + resp_cols)));

                                        resp_quadros46.Add(new IntPoint((int)(tabela_respostas[59].X + ((tabela_respostas[60].X - tabela_respostas[59].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[59].Y + ((tabela_respostas[71].Y - tabela_respostas[59].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros47.Add(new IntPoint((int)(tabela_respostas[60].X + ((tabela_respostas[61].X - tabela_respostas[60].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[60].Y + ((tabela_respostas[72].Y - tabela_respostas[60].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros48.Add(new IntPoint((int)(tabela_respostas[61].X + ((tabela_respostas[62].X - tabela_respostas[61].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[61].Y + ((tabela_respostas[73].Y - tabela_respostas[61].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros49.Add(new IntPoint((int)(tabela_respostas[62].X + ((tabela_respostas[63].X - tabela_respostas[62].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[62].Y + ((tabela_respostas[74].Y - tabela_respostas[62].Y) / 2) - 2 + resp_cols)));
                                        resp_quadros50.Add(new IntPoint((int)(tabela_respostas[63].X + ((tabela_respostas[64].X - tabela_respostas[63].X) / 2) - 4 + resp_lins), (int)(tabela_respostas[63].Y + ((tabela_respostas[75].Y - tabela_respostas[63].Y) / 2) - 2 + resp_cols)));
                                    }
                                }
                                try
                                {
                                    byte[] valor_branco = uimage.Collect8bppPixelValues(resp_branco);
                                    byte[] resp_1 = uimage.Collect8bppPixelValues(resp_quadros1);
                                    byte[] resp_2 = uimage.Collect8bppPixelValues(resp_quadros2);
                                    byte[] resp_3 = uimage.Collect8bppPixelValues(resp_quadros3);
                                    byte[] resp_4 = uimage.Collect8bppPixelValues(resp_quadros4);
                                    byte[] resp_5 = uimage.Collect8bppPixelValues(resp_quadros5);
                                    byte[] resp_6 = uimage.Collect8bppPixelValues(resp_quadros6);
                                    byte[] resp_7 = uimage.Collect8bppPixelValues(resp_quadros7);
                                    byte[] resp_8 = uimage.Collect8bppPixelValues(resp_quadros8);
                                    byte[] resp_9 = uimage.Collect8bppPixelValues(resp_quadros9);
                                    byte[] resp_10 = uimage.Collect8bppPixelValues(resp_quadros10);
                                    byte[] resp_11 = uimage.Collect8bppPixelValues(resp_quadros11);
                                    byte[] resp_12 = uimage.Collect8bppPixelValues(resp_quadros12);
                                    byte[] resp_13 = uimage.Collect8bppPixelValues(resp_quadros13);
                                    byte[] resp_14 = uimage.Collect8bppPixelValues(resp_quadros14);
                                    byte[] resp_15 = uimage.Collect8bppPixelValues(resp_quadros15);
                                    byte[] resp_16 = uimage.Collect8bppPixelValues(resp_quadros16);
                                    byte[] resp_17 = uimage.Collect8bppPixelValues(resp_quadros17);
                                    byte[] resp_18 = uimage.Collect8bppPixelValues(resp_quadros18);
                                    byte[] resp_19 = uimage.Collect8bppPixelValues(resp_quadros19);
                                    byte[] resp_20 = uimage.Collect8bppPixelValues(resp_quadros20);
                                    byte[] resp_21 = uimage.Collect8bppPixelValues(resp_quadros21);
                                    byte[] resp_22 = uimage.Collect8bppPixelValues(resp_quadros22);
                                    byte[] resp_23 = uimage.Collect8bppPixelValues(resp_quadros23);
                                    byte[] resp_24 = uimage.Collect8bppPixelValues(resp_quadros24);
                                    byte[] resp_25 = uimage.Collect8bppPixelValues(resp_quadros25);
                                    byte[] resp_26 = uimage.Collect8bppPixelValues(resp_quadros26);
                                    byte[] resp_27 = uimage.Collect8bppPixelValues(resp_quadros27);
                                    byte[] resp_28 = uimage.Collect8bppPixelValues(resp_quadros28);
                                    byte[] resp_29 = uimage.Collect8bppPixelValues(resp_quadros29);
                                    byte[] resp_30 = uimage.Collect8bppPixelValues(resp_quadros30);
                                    byte[] resp_31 = uimage.Collect8bppPixelValues(resp_quadros31);
                                    byte[] resp_32 = uimage.Collect8bppPixelValues(resp_quadros32);
                                    byte[] resp_33 = uimage.Collect8bppPixelValues(resp_quadros33);
                                    byte[] resp_34 = uimage.Collect8bppPixelValues(resp_quadros34);
                                    byte[] resp_35 = uimage.Collect8bppPixelValues(resp_quadros35);
                                    byte[] resp_36 = uimage.Collect8bppPixelValues(resp_quadros36);
                                    byte[] resp_37 = uimage.Collect8bppPixelValues(resp_quadros37);
                                    byte[] resp_38 = uimage.Collect8bppPixelValues(resp_quadros38);
                                    byte[] resp_39 = uimage.Collect8bppPixelValues(resp_quadros39);
                                    byte[] resp_40 = uimage.Collect8bppPixelValues(resp_quadros40);
                                    byte[] resp_41 = uimage.Collect8bppPixelValues(resp_quadros41);
                                    byte[] resp_42 = uimage.Collect8bppPixelValues(resp_quadros42);
                                    byte[] resp_43 = uimage.Collect8bppPixelValues(resp_quadros43);
                                    byte[] resp_44 = uimage.Collect8bppPixelValues(resp_quadros44);
                                    byte[] resp_45 = uimage.Collect8bppPixelValues(resp_quadros45);
                                    byte[] resp_46 = uimage.Collect8bppPixelValues(resp_quadros46);
                                    byte[] resp_47 = uimage.Collect8bppPixelValues(resp_quadros47);
                                    byte[] resp_48 = uimage.Collect8bppPixelValues(resp_quadros48);
                                    byte[] resp_49 = uimage.Collect8bppPixelValues(resp_quadros49);
                                    byte[] resp_50 = uimage.Collect8bppPixelValues(resp_quadros50);

                                    float dif_resp1 = 0, dif_resp2 = 0, dif_resp3 = 0, dif_resp4 = 0, dif_resp5 = 0, dif_resp6 = 0, dif_resp7 = 0, dif_resp8 = 0, dif_resp9 = 0, dif_resp10 = 0, dif_resp11 = 0, dif_resp12 = 0, dif_resp13 = 0, dif_resp14 = 0, dif_resp15 = 0, dif_resp16 = 0, dif_resp17 = 0, dif_resp18 = 0, dif_resp19 = 0, dif_resp20 = 0, dif_resp21 = 0, dif_resp22 = 0, dif_resp23 = 0, dif_resp24 = 0, dif_resp25 = 0, dif_resp26 = 0, dif_resp27 = 0, dif_resp28 = 0, dif_resp29 = 0, dif_resp30 = 0, dif_resp31 = 0, dif_resp32 = 0, dif_resp33 = 0, dif_resp34 = 0, dif_resp35 = 0, dif_resp36 = 0, dif_resp37 = 0, dif_resp38 = 0, dif_resp39 = 0, dif_resp40 = 0, dif_resp41 = 0, dif_resp42 = 0, dif_resp43 = 0, dif_resp44 = 0, dif_resp45 = 0, dif_resp46 = 0, dif_resp47 = 0, dif_resp48 = 0, dif_resp49 = 0, dif_resp50 = 0;
                                    for (int k = 0; k < 77; k++)
                                    {
                                        dif_resp1 += (valor_branco[k] - resp_1[k]);
                                        dif_resp2 += (valor_branco[k] - resp_2[k]);
                                        dif_resp3 += (valor_branco[k] - resp_3[k]);
                                        dif_resp4 += (valor_branco[k] - resp_4[k]);
                                        dif_resp5 += (valor_branco[k] - resp_5[k]);
                                        dif_resp6 += (valor_branco[k] - resp_6[k]);
                                        dif_resp7 += (valor_branco[k] - resp_7[k]);
                                        dif_resp8 += (valor_branco[k] - resp_8[k]);
                                        dif_resp9 += (valor_branco[k] - resp_9[k]);
                                        dif_resp10 += (valor_branco[k] - resp_10[k]);
                                        dif_resp11 += (valor_branco[k] - resp_11[k]);
                                        dif_resp12 += (valor_branco[k] - resp_12[k]);
                                        dif_resp13 += (valor_branco[k] - resp_13[k]);
                                        dif_resp14 += (valor_branco[k] - resp_14[k]);
                                        dif_resp15 += (valor_branco[k] - resp_15[k]);
                                        dif_resp16 += (valor_branco[k] - resp_16[k]);
                                        dif_resp17 += (valor_branco[k] - resp_17[k]);
                                        dif_resp18 += (valor_branco[k] - resp_18[k]);
                                        dif_resp19 += (valor_branco[k] - resp_19[k]);
                                        dif_resp20 += (valor_branco[k] - resp_20[k]);
                                        dif_resp21 += (valor_branco[k] - resp_21[k]);
                                        dif_resp22 += (valor_branco[k] - resp_22[k]);
                                        dif_resp23 += (valor_branco[k] - resp_23[k]);
                                        dif_resp24 += (valor_branco[k] - resp_24[k]);
                                        dif_resp25 += (valor_branco[k] - resp_25[k]);
                                        dif_resp26 += (valor_branco[k] - resp_26[k]);
                                        dif_resp27 += (valor_branco[k] - resp_27[k]);
                                        dif_resp28 += (valor_branco[k] - resp_28[k]);
                                        dif_resp29 += (valor_branco[k] - resp_29[k]);
                                        dif_resp30 += (valor_branco[k] - resp_30[k]);
                                        dif_resp31 += (valor_branco[k] - resp_31[k]);
                                        dif_resp32 += (valor_branco[k] - resp_32[k]);
                                        dif_resp33 += (valor_branco[k] - resp_33[k]);
                                        dif_resp34 += (valor_branco[k] - resp_34[k]);
                                        dif_resp35 += (valor_branco[k] - resp_35[k]);
                                        dif_resp36 += (valor_branco[k] - resp_36[k]);
                                        dif_resp37 += (valor_branco[k] - resp_37[k]);
                                        dif_resp38 += (valor_branco[k] - resp_38[k]);
                                        dif_resp39 += (valor_branco[k] - resp_39[k]);
                                        dif_resp40 += (valor_branco[k] - resp_40[k]);
                                        dif_resp41 += (valor_branco[k] - resp_41[k]);
                                        dif_resp42 += (valor_branco[k] - resp_42[k]);
                                        dif_resp43 += (valor_branco[k] - resp_43[k]);
                                        dif_resp44 += (valor_branco[k] - resp_44[k]);
                                        dif_resp45 += (valor_branco[k] - resp_45[k]);
                                        dif_resp46 += (valor_branco[k] - resp_46[k]);
                                        dif_resp47 += (valor_branco[k] - resp_47[k]);
                                        dif_resp48 += (valor_branco[k] - resp_48[k]);
                                        dif_resp49 += (valor_branco[k] - resp_49[k]);
                                        dif_resp50 += (valor_branco[k] - resp_50[k]);
                                    }
                                    int cor_de_resposta = 1500;
                                    int itens_identificados = 0;
                                    string[] respostas = new string[10];
                                    if (dif_resp1 > cor_de_resposta) { respostas[0] = "A"; itens_identificados++; }
                                    if (dif_resp2 > cor_de_resposta) { if (respostas[0] == null) { respostas[0] = "B"; } else { respostas[0] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp3 > cor_de_resposta) { if (respostas[0] == null) { respostas[0] = "C"; } else { respostas[0] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp4 > cor_de_resposta) { if (respostas[0] == null) { respostas[0] = "D"; } else { respostas[0] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp5 > cor_de_resposta) { if (respostas[0] == null) { respostas[0] = "E"; } else { respostas[0] = "Nulo"; } itens_identificados++; }

                                    if (dif_resp6 > cor_de_resposta) { respostas[5] = "A"; itens_identificados++; }
                                    if (dif_resp7 > cor_de_resposta) { if (respostas[5] == null) { respostas[5] = "B"; } else { respostas[5] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp8 > cor_de_resposta) { if (respostas[5] == null) { respostas[5] = "C"; } else { respostas[5] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp9 > cor_de_resposta) { if (respostas[5] == null) { respostas[5] = "D"; } else { respostas[5] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp10 > cor_de_resposta) { if (respostas[5] == null) { respostas[5] = "E"; } else { respostas[5] = "Nulo"; } itens_identificados++; }

                                    if (dif_resp11 > cor_de_resposta) { respostas[1] = "A"; itens_identificados++; }
                                    if (dif_resp12 > cor_de_resposta) { if (respostas[1] == null) { respostas[1] = "B"; } else { respostas[1] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp13 > cor_de_resposta) { if (respostas[1] == null) { respostas[1] = "C"; } else { respostas[1] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp14 > cor_de_resposta) { if (respostas[1] == null) { respostas[1] = "D"; } else { respostas[1] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp15 > cor_de_resposta) { if (respostas[1] == null) { respostas[1] = "E"; } else { respostas[1] = "Nulo"; } itens_identificados++; }

                                    if (dif_resp16 > cor_de_resposta) { respostas[6] = "A"; itens_identificados++; }
                                    if (dif_resp17 > cor_de_resposta) { if (respostas[6] == null) { respostas[6] = "B"; } else { respostas[6] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp18 > cor_de_resposta) { if (respostas[6] == null) { respostas[6] = "C"; } else { respostas[6] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp19 > cor_de_resposta) { if (respostas[6] == null) { respostas[6] = "D"; } else { respostas[6] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp20 > cor_de_resposta) { if (respostas[6] == null) { respostas[6] = "E"; } else { respostas[6] = "Nulo"; } itens_identificados++; }

                                    if (dif_resp21 > cor_de_resposta) { respostas[2] = "A"; itens_identificados++; }
                                    if (dif_resp22 > cor_de_resposta) { if (respostas[2] == null) { respostas[2] = "B"; } else { respostas[2] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp23 > cor_de_resposta) { if (respostas[2] == null) { respostas[2] = "C"; } else { respostas[2] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp24 > cor_de_resposta) { if (respostas[2] == null) { respostas[2] = "D"; } else { respostas[2] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp25 > cor_de_resposta) { if (respostas[2] == null) { respostas[2] = "E"; } else { respostas[2] = "Nulo"; } itens_identificados++; }

                                    if (dif_resp26 > cor_de_resposta) { respostas[7] = "A"; itens_identificados++; }
                                    if (dif_resp27 > cor_de_resposta) { if (respostas[7] == null) { respostas[7] = "B"; } else { respostas[7] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp28 > cor_de_resposta) { if (respostas[7] == null) { respostas[7] = "C"; } else { respostas[7] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp29 > cor_de_resposta) { if (respostas[7] == null) { respostas[7] = "D"; } else { respostas[7] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp30 > cor_de_resposta) { if (respostas[7] == null) { respostas[7] = "E"; } else { respostas[7] = "Nulo"; } itens_identificados++; }

                                    if (dif_resp31 > cor_de_resposta) { respostas[3] = "A"; itens_identificados++; }
                                    if (dif_resp32 > cor_de_resposta) { if (respostas[3] == null) { respostas[3] = "B"; } else { respostas[3] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp33 > cor_de_resposta) { if (respostas[3] == null) { respostas[3] = "C"; } else { respostas[3] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp34 > cor_de_resposta) { if (respostas[3] == null) { respostas[3] = "D"; } else { respostas[3] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp35 > cor_de_resposta) { if (respostas[3] == null) { respostas[3] = "E"; } else { respostas[3] = "Nulo"; } itens_identificados++; }

                                    if (dif_resp36 > cor_de_resposta) { respostas[8] = "A"; itens_identificados++; }
                                    if (dif_resp37 > cor_de_resposta) { if (respostas[8] == null) { respostas[8] = "B"; } else { respostas[8] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp38 > cor_de_resposta) { if (respostas[8] == null) { respostas[8] = "C"; } else { respostas[8] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp39 > cor_de_resposta) { if (respostas[8] == null) { respostas[8] = "D"; } else { respostas[8] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp40 > cor_de_resposta) { if (respostas[8] == null) { respostas[8] = "E"; } else { respostas[8] = "Nulo"; } itens_identificados++; }

                                    if (dif_resp41 > cor_de_resposta) { respostas[4] = "A"; itens_identificados++; }
                                    if (dif_resp42 > cor_de_resposta) { if (respostas[4] == null) { respostas[4] = "B"; } else { respostas[4] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp43 > cor_de_resposta) { if (respostas[4] == null) { respostas[4] = "C"; } else { respostas[4] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp44 > cor_de_resposta) { if (respostas[4] == null) { respostas[4] = "D"; } else { respostas[4] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp45 > cor_de_resposta) { if (respostas[4] == null) { respostas[4] = "E"; } else { respostas[4] = "Nulo"; } itens_identificados++; }

                                    if (dif_resp46 > cor_de_resposta) { respostas[9] = "A"; itens_identificados++; }
                                    if (dif_resp47 > cor_de_resposta) { if (respostas[9] == null) { respostas[9] = "B"; } else { respostas[9] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp48 > cor_de_resposta) { if (respostas[9] == null) { respostas[9] = "C"; } else { respostas[9] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp49 > cor_de_resposta) { if (respostas[9] == null) { respostas[9] = "D"; } else { respostas[9] = "Nulo"; } itens_identificados++; }
                                    if (dif_resp50 > cor_de_resposta) { if (respostas[9] == null) { respostas[9] = "E"; } else { respostas[9] = "Nulo"; } itens_identificados++; }


                            for (int colunas = 0; colunas < 17; colunas++)
                            {
                                for (int linhas = 0; linhas < 6; linhas++)
                                {
                                    tabela_codigo[(linhas * 17) + colunas] = new System.Drawing.PointF((float)((pontoX0 - 3) + (colunas * (varX / 16)) + (linhas * dif_pos1 / 16) - Math.PI * 2 *(varY1 - varY0)), (float)((pontoY00) + ((linhas * 3)/5) + (linhas * ((colunas * ((varY1 - varY0 - 1) / 16) / 2) + varY0)) + ((colunas * dif_pos0-1) / 16)));
                                }
                            }

                            for (int cod_cols = 0; cod_cols < 9; cod_cols++)
                            {
                                for (int cod_lins = 0; cod_lins < 9; cod_lins++)
                                {
                                    papel_branco.Add(new IntPoint((int)((pontoX0) + 2 + cod_lins), (int)((pontoY00) + 6 + cod_cols)));
                                    quadro1.Add(new IntPoint((int)(tabela_codigo[1].X + ((tabela_codigo[2].X - tabela_codigo[1].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[1].Y + ((tabela_codigo[18].Y - tabela_codigo[1].Y) / 2) - 3 + cod_cols)));
                                    quadro2.Add(new IntPoint((int)(tabela_codigo[2].X + ((tabela_codigo[3].X - tabela_codigo[2].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[2].Y + ((tabela_codigo[19].Y - tabela_codigo[2].Y) / 2) - 3 + cod_cols)));
                                    quadro3.Add(new IntPoint((int)(tabela_codigo[3].X + ((tabela_codigo[4].X - tabela_codigo[3].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[3].Y + ((tabela_codigo[20].Y - tabela_codigo[3].Y) / 2) - 3 + cod_cols)));
                                    quadro4.Add(new IntPoint((int)(tabela_codigo[4].X + ((tabela_codigo[5].X - tabela_codigo[4].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[4].Y + ((tabela_codigo[21].Y - tabela_codigo[4].Y) / 2) - 3 + cod_cols)));
                                    quadro5.Add(new IntPoint((int)(tabela_codigo[5].X + ((tabela_codigo[6].X - tabela_codigo[5].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[5].Y + ((tabela_codigo[22].Y - tabela_codigo[5].Y) / 2) - 3 + cod_cols)));
                                    quadro6.Add(new IntPoint((int)(tabela_codigo[6].X + ((tabela_codigo[7].X - tabela_codigo[6].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[6].Y + ((tabela_codigo[23].Y - tabela_codigo[6].Y) / 2) - 3 + cod_cols)));
                                    quadro7.Add(new IntPoint((int)(tabela_codigo[7].X + ((tabela_codigo[8].X - tabela_codigo[7].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[7].Y + ((tabela_codigo[24].Y - tabela_codigo[7].Y) / 2) - 3 + cod_cols)));
                                    quadro8.Add(new IntPoint((int)(tabela_codigo[8].X + ((tabela_codigo[9].X - tabela_codigo[8].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[8].Y + ((tabela_codigo[25].Y - tabela_codigo[8].Y) / 2) - 3 + cod_cols)));
                                    quadro9.Add(new IntPoint((int)(tabela_codigo[9].X + ((tabela_codigo[10].X - tabela_codigo[9].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[9].Y + ((tabela_codigo[26].Y - tabela_codigo[9].Y) / 2) - 3 + cod_cols)));
                                    quadro10.Add(new IntPoint((int)(tabela_codigo[10].X + ((tabela_codigo[11].X - tabela_codigo[10].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[10].Y + ((tabela_codigo[27].Y - tabela_codigo[10].Y) / 2) - 3 + cod_cols)));
                                    quadro11.Add(new IntPoint((int)(tabela_codigo[11].X + ((tabela_codigo[12].X - tabela_codigo[11].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[11].Y + ((tabela_codigo[28].Y - tabela_codigo[11].Y) / 2) - 3 + cod_cols)));
                                    quadro12.Add(new IntPoint((int)(tabela_codigo[12].X + ((tabela_codigo[13].X - tabela_codigo[12].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[12].Y + ((tabela_codigo[29].Y - tabela_codigo[12].Y) / 2) - 3 + cod_cols)));
                                    quadro13.Add(new IntPoint((int)(tabela_codigo[13].X + ((tabela_codigo[14].X - tabela_codigo[13].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[13].Y + ((tabela_codigo[30].Y - tabela_codigo[13].Y) / 2) - 3 + cod_cols)));
                                    quadro14.Add(new IntPoint((int)(tabela_codigo[14].X + ((tabela_codigo[15].X - tabela_codigo[14].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[14].Y + ((tabela_codigo[31].Y - tabela_codigo[14].Y) / 2) - 3 + cod_cols)));
                                    quadro15.Add(new IntPoint((int)(tabela_codigo[15].X + ((tabela_codigo[16].X - tabela_codigo[15].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[15].Y + ((tabela_codigo[32].Y - tabela_codigo[15].Y) / 2) - 3 + cod_cols)));

                                    quadro16.Add(new IntPoint((int)(tabela_codigo[18].X + ((tabela_codigo[19].X - tabela_codigo[18].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[18].Y + ((tabela_codigo[35].Y - tabela_codigo[18].Y) / 2) - 3 + cod_cols)));
                                    quadro17.Add(new IntPoint((int)(tabela_codigo[19].X + ((tabela_codigo[20].X - tabela_codigo[19].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[19].Y + ((tabela_codigo[36].Y - tabela_codigo[19].Y) / 2) - 3 + cod_cols)));
                                    quadro18.Add(new IntPoint((int)(tabela_codigo[20].X + ((tabela_codigo[21].X - tabela_codigo[20].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[20].Y + ((tabela_codigo[37].Y - tabela_codigo[20].Y) / 2) - 3 + cod_cols)));
                                    quadro19.Add(new IntPoint((int)(tabela_codigo[21].X + ((tabela_codigo[22].X - tabela_codigo[21].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[21].Y + ((tabela_codigo[38].Y - tabela_codigo[21].Y) / 2) - 3 + cod_cols)));
                                    quadro20.Add(new IntPoint((int)(tabela_codigo[22].X + ((tabela_codigo[23].X - tabela_codigo[22].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[22].Y + ((tabela_codigo[39].Y - tabela_codigo[22].Y) / 2) - 3 + cod_cols)));
                                    quadro21.Add(new IntPoint((int)(tabela_codigo[23].X + ((tabela_codigo[24].X - tabela_codigo[23].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[23].Y + ((tabela_codigo[40].Y - tabela_codigo[23].Y) / 2) - 3 + cod_cols)));
                                    quadro22.Add(new IntPoint((int)(tabela_codigo[24].X + ((tabela_codigo[25].X - tabela_codigo[24].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[24].Y + ((tabela_codigo[41].Y - tabela_codigo[24].Y) / 2) - 3 + cod_cols)));
                                    quadro23.Add(new IntPoint((int)(tabela_codigo[25].X + ((tabela_codigo[26].X - tabela_codigo[25].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[25].Y + ((tabela_codigo[42].Y - tabela_codigo[25].Y) / 2) - 3 + cod_cols)));
                                    quadro24.Add(new IntPoint((int)(tabela_codigo[26].X + ((tabela_codigo[27].X - tabela_codigo[26].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[26].Y + ((tabela_codigo[43].Y - tabela_codigo[26].Y) / 2) - 3 + cod_cols)));
                                    quadro25.Add(new IntPoint((int)(tabela_codigo[27].X + ((tabela_codigo[28].X - tabela_codigo[27].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[27].Y + ((tabela_codigo[44].Y - tabela_codigo[27].Y) / 2) - 3 + cod_cols)));
                                    quadro26.Add(new IntPoint((int)(tabela_codigo[28].X + ((tabela_codigo[29].X - tabela_codigo[28].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[28].Y + ((tabela_codigo[45].Y - tabela_codigo[28].Y) / 2) - 3 + cod_cols)));
                                    quadro27.Add(new IntPoint((int)(tabela_codigo[29].X + ((tabela_codigo[30].X - tabela_codigo[29].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[29].Y + ((tabela_codigo[46].Y - tabela_codigo[29].Y) / 2) - 3 + cod_cols)));
                                    quadro28.Add(new IntPoint((int)(tabela_codigo[30].X + ((tabela_codigo[31].X - tabela_codigo[30].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[30].Y + ((tabela_codigo[47].Y - tabela_codigo[30].Y) / 2) - 3 + cod_cols)));
                                    quadro29.Add(new IntPoint((int)(tabela_codigo[31].X + ((tabela_codigo[32].X - tabela_codigo[31].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[31].Y + ((tabela_codigo[48].Y - tabela_codigo[31].Y) / 2) - 3 + cod_cols)));
                                    quadro30.Add(new IntPoint((int)(tabela_codigo[32].X + ((tabela_codigo[33].X - tabela_codigo[32].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[32].Y + ((tabela_codigo[49].Y - tabela_codigo[32].Y) / 2) - 3 + cod_cols)));

                                    quadro31.Add(new IntPoint((int)(tabela_codigo[35].X + ((tabela_codigo[36].X - tabela_codigo[35].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[35].Y + ((tabela_codigo[52].Y - tabela_codigo[35].Y) / 2) - 3 + cod_cols)));
                                    quadro32.Add(new IntPoint((int)(tabela_codigo[36].X + ((tabela_codigo[37].X - tabela_codigo[36].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[36].Y + ((tabela_codigo[53].Y - tabela_codigo[36].Y) / 2) - 3 + cod_cols)));
                                    quadro33.Add(new IntPoint((int)(tabela_codigo[37].X + ((tabela_codigo[38].X - tabela_codigo[37].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[37].Y + ((tabela_codigo[54].Y - tabela_codigo[37].Y) / 2) - 3 + cod_cols)));
                                    quadro34.Add(new IntPoint((int)(tabela_codigo[38].X + ((tabela_codigo[39].X - tabela_codigo[38].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[38].Y + ((tabela_codigo[55].Y - tabela_codigo[38].Y) / 2) - 3 + cod_cols)));
                                    quadro35.Add(new IntPoint((int)(tabela_codigo[39].X + ((tabela_codigo[40].X - tabela_codigo[39].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[39].Y + ((tabela_codigo[56].Y - tabela_codigo[39].Y) / 2) - 3 + cod_cols)));
                                    quadro36.Add(new IntPoint((int)(tabela_codigo[40].X + ((tabela_codigo[41].X - tabela_codigo[40].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[40].Y + ((tabela_codigo[57].Y - tabela_codigo[40].Y) / 2) - 3 + cod_cols)));
                                    quadro37.Add(new IntPoint((int)(tabela_codigo[41].X + ((tabela_codigo[42].X - tabela_codigo[41].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[41].Y + ((tabela_codigo[58].Y - tabela_codigo[41].Y) / 2) - 3 + cod_cols)));
                                    quadro38.Add(new IntPoint((int)(tabela_codigo[42].X + ((tabela_codigo[43].X - tabela_codigo[42].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[42].Y + ((tabela_codigo[59].Y - tabela_codigo[42].Y) / 2) - 3 + cod_cols)));
                                    quadro39.Add(new IntPoint((int)(tabela_codigo[43].X + ((tabela_codigo[44].X - tabela_codigo[43].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[43].Y + ((tabela_codigo[60].Y - tabela_codigo[43].Y) / 2) - 3 + cod_cols)));
                                    quadro40.Add(new IntPoint((int)(tabela_codigo[44].X + ((tabela_codigo[45].X - tabela_codigo[44].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[44].Y + ((tabela_codigo[61].Y - tabela_codigo[44].Y) / 2) - 3 + cod_cols)));
                                    quadro41.Add(new IntPoint((int)(tabela_codigo[45].X + ((tabela_codigo[46].X - tabela_codigo[45].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[45].Y + ((tabela_codigo[62].Y - tabela_codigo[45].Y) / 2) - 3 + cod_cols)));
                                    quadro42.Add(new IntPoint((int)(tabela_codigo[46].X + ((tabela_codigo[47].X - tabela_codigo[46].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[46].Y + ((tabela_codigo[63].Y - tabela_codigo[46].Y) / 2) - 3 + cod_cols)));
                                    quadro43.Add(new IntPoint((int)(tabela_codigo[47].X + ((tabela_codigo[48].X - tabela_codigo[47].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[47].Y + ((tabela_codigo[64].Y - tabela_codigo[47].Y) / 2) - 3 + cod_cols)));
                                    quadro44.Add(new IntPoint((int)(tabela_codigo[48].X + ((tabela_codigo[49].X - tabela_codigo[48].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[48].Y + ((tabela_codigo[65].Y - tabela_codigo[48].Y) / 2) - 3 + cod_cols)));
                                    quadro45.Add(new IntPoint((int)(tabela_codigo[49].X + ((tabela_codigo[50].X - tabela_codigo[49].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[49].Y + ((tabela_codigo[66].Y - tabela_codigo[49].Y) / 2) - 3 + cod_cols)));

                                    quadro46.Add(new IntPoint((int)(tabela_codigo[52].X + ((tabela_codigo[53].X - tabela_codigo[52].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[52].Y + ((tabela_codigo[69].Y - tabela_codigo[52].Y) / 2) - 3 + cod_cols)));
                                    quadro47.Add(new IntPoint((int)(tabela_codigo[53].X + ((tabela_codigo[54].X - tabela_codigo[53].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[53].Y + ((tabela_codigo[70].Y - tabela_codigo[53].Y) / 2) - 3 + cod_cols)));
                                    quadro48.Add(new IntPoint((int)(tabela_codigo[54].X + ((tabela_codigo[55].X - tabela_codigo[54].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[54].Y + ((tabela_codigo[71].Y - tabela_codigo[54].Y) / 2) - 3 + cod_cols)));
                                    quadro49.Add(new IntPoint((int)(tabela_codigo[55].X + ((tabela_codigo[56].X - tabela_codigo[55].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[55].Y + ((tabela_codigo[72].Y - tabela_codigo[55].Y) / 2) - 3 + cod_cols)));
                                    quadro50.Add(new IntPoint((int)(tabela_codigo[56].X + ((tabela_codigo[57].X - tabela_codigo[56].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[56].Y + ((tabela_codigo[73].Y - tabela_codigo[56].Y) / 2) - 3 + cod_cols)));
                                    quadro51.Add(new IntPoint((int)(tabela_codigo[57].X + ((tabela_codigo[58].X - tabela_codigo[57].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[57].Y + ((tabela_codigo[74].Y - tabela_codigo[57].Y) / 2) - 3 + cod_cols)));
                                    quadro52.Add(new IntPoint((int)(tabela_codigo[58].X + ((tabela_codigo[59].X - tabela_codigo[58].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[58].Y + ((tabela_codigo[75].Y - tabela_codigo[58].Y) / 2) - 3 + cod_cols)));
                                    quadro53.Add(new IntPoint((int)(tabela_codigo[59].X + ((tabela_codigo[60].X - tabela_codigo[59].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[59].Y + ((tabela_codigo[76].Y - tabela_codigo[59].Y) / 2) - 3 + cod_cols)));
                                    quadro54.Add(new IntPoint((int)(tabela_codigo[60].X + ((tabela_codigo[61].X - tabela_codigo[60].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[60].Y + ((tabela_codigo[77].Y - tabela_codigo[60].Y) / 2) - 3 + cod_cols)));
                                    quadro55.Add(new IntPoint((int)(tabela_codigo[61].X + ((tabela_codigo[62].X - tabela_codigo[61].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[61].Y + ((tabela_codigo[78].Y - tabela_codigo[61].Y) / 2) - 3 + cod_cols)));
                                    quadro56.Add(new IntPoint((int)(tabela_codigo[62].X + ((tabela_codigo[63].X - tabela_codigo[62].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[62].Y + ((tabela_codigo[79].Y - tabela_codigo[62].Y) / 2) - 3 + cod_cols)));
                                    quadro57.Add(new IntPoint((int)(tabela_codigo[63].X + ((tabela_codigo[64].X - tabela_codigo[63].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[63].Y + ((tabela_codigo[80].Y - tabela_codigo[63].Y) / 2) - 3 + cod_cols)));
                                    quadro58.Add(new IntPoint((int)(tabela_codigo[64].X + ((tabela_codigo[65].X - tabela_codigo[64].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[64].Y + ((tabela_codigo[81].Y - tabela_codigo[64].Y) / 2) - 3 + cod_cols)));
                                    quadro59.Add(new IntPoint((int)(tabela_codigo[65].X + ((tabela_codigo[66].X - tabela_codigo[65].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[65].Y + ((tabela_codigo[82].Y - tabela_codigo[65].Y) / 2) - 3 + cod_cols)));
                                    quadro60.Add(new IntPoint((int)(tabela_codigo[66].X + ((tabela_codigo[67].X - tabela_codigo[66].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[66].Y + ((tabela_codigo[83].Y - tabela_codigo[66].Y) / 2) - 3 + cod_cols)));

                                    quadro61.Add(new IntPoint((int)(tabela_codigo[69].X + ((tabela_codigo[70].X - tabela_codigo[69].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[69].Y + ((tabela_codigo[86].Y - tabela_codigo[69].Y) / 2) - 3 + cod_cols)));
                                    quadro62.Add(new IntPoint((int)(tabela_codigo[70].X + ((tabela_codigo[71].X - tabela_codigo[70].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[70].Y + ((tabela_codigo[87].Y - tabela_codigo[70].Y) / 2) - 3 + cod_cols)));
                                    quadro63.Add(new IntPoint((int)(tabela_codigo[71].X + ((tabela_codigo[72].X - tabela_codigo[71].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[71].Y + ((tabela_codigo[88].Y - tabela_codigo[71].Y) / 2) - 3 + cod_cols)));
                                    quadro64.Add(new IntPoint((int)(tabela_codigo[72].X + ((tabela_codigo[73].X - tabela_codigo[72].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[72].Y + ((tabela_codigo[89].Y - tabela_codigo[72].Y) / 2) - 3 + cod_cols)));
                                    quadro65.Add(new IntPoint((int)(tabela_codigo[73].X + ((tabela_codigo[74].X - tabela_codigo[73].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[73].Y + ((tabela_codigo[90].Y - tabela_codigo[73].Y) / 2) - 3 + cod_cols)));
                                    quadro66.Add(new IntPoint((int)(tabela_codigo[74].X + ((tabela_codigo[75].X - tabela_codigo[74].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[74].Y + ((tabela_codigo[91].Y - tabela_codigo[74].Y) / 2) - 3 + cod_cols)));
                                    quadro67.Add(new IntPoint((int)(tabela_codigo[75].X + ((tabela_codigo[76].X - tabela_codigo[75].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[75].Y + ((tabela_codigo[92].Y - tabela_codigo[75].Y) / 2) - 3 + cod_cols)));
                                    quadro68.Add(new IntPoint((int)(tabela_codigo[76].X + ((tabela_codigo[77].X - tabela_codigo[76].X) / 2) - 5 + cod_lins), (int)(tabela_codigo[76].Y + ((tabela_codigo[93].Y - tabela_codigo[76].Y) / 2) - 3 + cod_cols)));
                                }
                            }

                            byte[] branco = uimage.Collect8bppPixelValues(papel_branco);
                            byte[] quadro_1 = uimage.Collect8bppPixelValues(quadro1);
                            byte[] quadro_2 = uimage.Collect8bppPixelValues(quadro2);
                            byte[] quadro_3 = uimage.Collect8bppPixelValues(quadro3);
                            byte[] quadro_4 = uimage.Collect8bppPixelValues(quadro4);
                            byte[] quadro_5 = uimage.Collect8bppPixelValues(quadro5);
                            byte[] quadro_6 = uimage.Collect8bppPixelValues(quadro6);
                            byte[] quadro_7 = uimage.Collect8bppPixelValues(quadro7);
                            byte[] quadro_8 = uimage.Collect8bppPixelValues(quadro8);
                            byte[] quadro_9 = uimage.Collect8bppPixelValues(quadro9);
                            byte[] quadro_10 = uimage.Collect8bppPixelValues(quadro10);
                            byte[] quadro_11 = uimage.Collect8bppPixelValues(quadro11);
                            byte[] quadro_12 = uimage.Collect8bppPixelValues(quadro12);
                            byte[] quadro_13 = uimage.Collect8bppPixelValues(quadro13);
                            byte[] quadro_14 = uimage.Collect8bppPixelValues(quadro14);
                            byte[] quadro_15 = uimage.Collect8bppPixelValues(quadro15);
                            byte[] quadro_16 = uimage.Collect8bppPixelValues(quadro16);
                            byte[] quadro_17 = uimage.Collect8bppPixelValues(quadro17);
                            byte[] quadro_18 = uimage.Collect8bppPixelValues(quadro18);
                            byte[] quadro_19 = uimage.Collect8bppPixelValues(quadro19);
                            byte[] quadro_20 = uimage.Collect8bppPixelValues(quadro20);
                            byte[] quadro_21 = uimage.Collect8bppPixelValues(quadro21);
                            byte[] quadro_22 = uimage.Collect8bppPixelValues(quadro22);
                            byte[] quadro_23 = uimage.Collect8bppPixelValues(quadro23);
                            byte[] quadro_24 = uimage.Collect8bppPixelValues(quadro24);
                            byte[] quadro_25 = uimage.Collect8bppPixelValues(quadro25);
                            byte[] quadro_26 = uimage.Collect8bppPixelValues(quadro26);
                            byte[] quadro_27 = uimage.Collect8bppPixelValues(quadro27);
                            byte[] quadro_28 = uimage.Collect8bppPixelValues(quadro28);
                            byte[] quadro_29 = uimage.Collect8bppPixelValues(quadro29);
                            byte[] quadro_30 = uimage.Collect8bppPixelValues(quadro30);
                            byte[] quadro_31 = uimage.Collect8bppPixelValues(quadro31);
                            byte[] quadro_32 = uimage.Collect8bppPixelValues(quadro32);
                            byte[] quadro_33 = uimage.Collect8bppPixelValues(quadro33);
                            byte[] quadro_34 = uimage.Collect8bppPixelValues(quadro34);
                            byte[] quadro_35 = uimage.Collect8bppPixelValues(quadro35);
                            byte[] quadro_36 = uimage.Collect8bppPixelValues(quadro36);
                            byte[] quadro_37 = uimage.Collect8bppPixelValues(quadro37);
                            byte[] quadro_38 = uimage.Collect8bppPixelValues(quadro38);
                            byte[] quadro_39 = uimage.Collect8bppPixelValues(quadro39);
                            byte[] quadro_40 = uimage.Collect8bppPixelValues(quadro40);
                            byte[] quadro_41 = uimage.Collect8bppPixelValues(quadro41);
                            byte[] quadro_42 = uimage.Collect8bppPixelValues(quadro42);
                            byte[] quadro_43 = uimage.Collect8bppPixelValues(quadro43);
                            byte[] quadro_44 = uimage.Collect8bppPixelValues(quadro44);
                            byte[] quadro_45 = uimage.Collect8bppPixelValues(quadro45);
                            byte[] quadro_46 = uimage.Collect8bppPixelValues(quadro46);
                            byte[] quadro_47 = uimage.Collect8bppPixelValues(quadro47);
                            byte[] quadro_48 = uimage.Collect8bppPixelValues(quadro48);
                            byte[] quadro_49 = uimage.Collect8bppPixelValues(quadro49);
                            byte[] quadro_50 = uimage.Collect8bppPixelValues(quadro50);
                            byte[] quadro_51 = uimage.Collect8bppPixelValues(quadro51);
                            byte[] quadro_52 = uimage.Collect8bppPixelValues(quadro52);
                            byte[] quadro_53 = uimage.Collect8bppPixelValues(quadro53);
                            byte[] quadro_54 = uimage.Collect8bppPixelValues(quadro54);
                            byte[] quadro_55 = uimage.Collect8bppPixelValues(quadro55);
                            byte[] quadro_56 = uimage.Collect8bppPixelValues(quadro56);
                            byte[] quadro_57 = uimage.Collect8bppPixelValues(quadro57);
                            byte[] quadro_58 = uimage.Collect8bppPixelValues(quadro58);
                            byte[] quadro_59 = uimage.Collect8bppPixelValues(quadro59);
                            byte[] quadro_60 = uimage.Collect8bppPixelValues(quadro60);
                            byte[] quadro_61 = uimage.Collect8bppPixelValues(quadro61);
                            byte[] quadro_62 = uimage.Collect8bppPixelValues(quadro62);
                            byte[] quadro_63 = uimage.Collect8bppPixelValues(quadro63);
                            byte[] quadro_64 = uimage.Collect8bppPixelValues(quadro64);
                            byte[] quadro_65 = uimage.Collect8bppPixelValues(quadro65);
                            byte[] quadro_66 = uimage.Collect8bppPixelValues(quadro66);
                            byte[] quadro_67 = uimage.Collect8bppPixelValues(quadro67);
                            byte[] quadro_68 = uimage.Collect8bppPixelValues(quadro68);

                            float dif_quadro1 = 0, dif_quadro2 = 0, dif_quadro3 = 0, dif_quadro4 = 0, dif_quadro5 = 0, dif_quadro6 = 0, dif_quadro7 = 0, dif_quadro8 = 0, dif_quadro9 = 0, dif_quadro10 = 0, dif_quadro11 = 0, dif_quadro12 = 0, dif_quadro13 = 0, dif_quadro14 = 0, dif_quadro15 = 0, dif_quadro16 = 0, dif_quadro17 = 0, dif_quadro18 = 0, dif_quadro19 = 0, dif_quadro20 = 0, dif_quadro21 = 0, dif_quadro22 = 0, dif_quadro23 = 0, dif_quadro24 = 0, dif_quadro25 = 0, dif_quadro26 = 0, dif_quadro27 = 0, dif_quadro28 = 0, dif_quadro29 = 0, dif_quadro30 = 0, dif_quadro31 = 0, dif_quadro32 = 0, dif_quadro33 = 0, dif_quadro34 = 0, dif_quadro35 = 0, dif_quadro36 = 0, dif_quadro37 = 0, dif_quadro38 = 0, dif_quadro39 = 0, dif_quadro40 = 0, dif_quadro41 = 0, dif_quadro42 = 0, dif_quadro43 = 0, dif_quadro44 = 0, dif_quadro45 = 0, dif_quadro46 = 0, dif_quadro47 = 0, dif_quadro48 = 0, dif_quadro49 = 0, dif_quadro50 = 0, dif_quadro51 = 0, dif_quadro52 = 0, dif_quadro53 = 0, dif_quadro54 = 0, dif_quadro55 = 0, dif_quadro56 = 0, dif_quadro57 = 0, dif_quadro58 = 0, dif_quadro59 = 0, dif_quadro60 = 0, dif_quadro61 = 0, dif_quadro62 = 0, dif_quadro63 = 0, dif_quadro64 = 0, dif_quadro65 = 0, dif_quadro66 = 0, dif_quadro67 = 0, dif_quadro68 = 0;

                            for (int k = 0; k < 80; k++)
                            {
                                ///dif entre branco e o resto
                                
                                dif_quadro1 += (branco[k] - quadro_1[k]);
                                dif_quadro2 += (branco[k] - quadro_2[k]);
                                dif_quadro3 += (branco[k] - quadro_3[k]);
                                dif_quadro4 += (branco[k] - quadro_4[k]);
                                dif_quadro5 += (branco[k] - quadro_5[k]);
                                dif_quadro6 += (branco[k] - quadro_6[k]);
                                dif_quadro7 += (branco[k] - quadro_7[k]);
                                dif_quadro8 += (branco[k] - quadro_8[k]);
                                dif_quadro9 += (branco[k] - quadro_9[k]);
                                dif_quadro10 += (branco[k] - quadro_10[k]);
                                dif_quadro11 += (branco[k] - quadro_11[k]);
                                dif_quadro12 += (branco[k] - quadro_12[k]);
                                dif_quadro13 += (branco[k] - quadro_13[k]);
                                dif_quadro14 += (branco[k] - quadro_14[k]);
                                dif_quadro15 += (branco[k] - quadro_15[k]);
                                dif_quadro16 += (branco[k] - quadro_16[k]);
                                dif_quadro17 += (branco[k] - quadro_17[k]);
                                dif_quadro18 += (branco[k] - quadro_18[k]);
                                dif_quadro19 += (branco[k] - quadro_19[k]);
                                dif_quadro20 += (branco[k] - quadro_20[k]);
                                dif_quadro21 += (branco[k] - quadro_21[k]);
                                dif_quadro22 += (branco[k] - quadro_22[k]);
                                dif_quadro23 += (branco[k] - quadro_23[k]);
                                dif_quadro24 += (branco[k] - quadro_24[k]);
                                dif_quadro25 += (branco[k] - quadro_25[k]);
                                dif_quadro26 += (branco[k] - quadro_26[k]);
                                dif_quadro27 += (branco[k] - quadro_27[k]);
                                dif_quadro28 += (branco[k] - quadro_28[k]);
                                dif_quadro29 += (branco[k] - quadro_29[k]);
                                dif_quadro30 += (branco[k] - quadro_30[k]);
                                dif_quadro31 += (branco[k] - quadro_31[k]);
                                dif_quadro32 += (branco[k] - quadro_32[k]);
                                dif_quadro33 += (branco[k] - quadro_33[k]);
                                dif_quadro34 += (branco[k] - quadro_34[k]);
                                dif_quadro35 += (branco[k] - quadro_35[k]);
                                dif_quadro36 += (branco[k] - quadro_36[k]);
                                dif_quadro37 += (branco[k] - quadro_37[k]);
                                dif_quadro38 += (branco[k] - quadro_38[k]);
                                dif_quadro39 += (branco[k] - quadro_39[k]);
                                dif_quadro40 += (branco[k] - quadro_40[k]);
                                dif_quadro41 += (branco[k] - quadro_41[k]);
                                dif_quadro42 += (branco[k] - quadro_42[k]);
                                dif_quadro43 += (branco[k] - quadro_43[k]);
                                dif_quadro44 += (branco[k] - quadro_44[k]);
                                dif_quadro45 += (branco[k] - quadro_45[k]);
                                dif_quadro46 += (branco[k] - quadro_46[k]);
                                dif_quadro47 += (branco[k] - quadro_47[k]);
                                dif_quadro48 += (branco[k] - quadro_48[k]);
                                dif_quadro49 += (branco[k] - quadro_49[k]);
                                dif_quadro50 += (branco[k] - quadro_50[k]);
                                dif_quadro51 += (branco[k] - quadro_51[k]);
                                dif_quadro52 += (branco[k] - quadro_52[k]);
                                dif_quadro53 += (branco[k] - quadro_53[k]);
                                dif_quadro54 += (branco[k] - quadro_54[k]);
                                dif_quadro55 += (branco[k] - quadro_55[k]);
                                dif_quadro56 += (branco[k] - quadro_56[k]);
                                dif_quadro57 += (branco[k] - quadro_57[k]);
                                dif_quadro58 += (branco[k] - quadro_58[k]);
                                dif_quadro59 += (branco[k] - quadro_59[k]);
                                dif_quadro60 += (branco[k] - quadro_60[k]);
                                dif_quadro61 += (branco[k] - quadro_61[k]);
                                dif_quadro62 += (branco[k] - quadro_62[k]);
                                dif_quadro63 += (branco[k] - quadro_63[k]);
                                dif_quadro64 += (branco[k] - quadro_64[k]);
                                dif_quadro65 += (branco[k] - quadro_65[k]);
                                dif_quadro66 += (branco[k] - quadro_66[k]);
                                dif_quadro67 += (branco[k] - quadro_67[k]);
                                dif_quadro68 += (branco[k] - quadro_68[k]);
                            }
                            long valor_codigo = 0;
                            int cor_de_corte = 4000;
                            int valor_verificador = 0;
                            int valor_v = 0;

                            if (dif_quadro1 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 0); valor_verificador += 1; }
                            if (dif_quadro2 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 1); valor_verificador += 1; }
                            if (dif_quadro3 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 2); valor_verificador += 1; }
                            if (dif_quadro4 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 3); valor_verificador += 1; }
                            if (dif_quadro5 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 4); valor_verificador += 1; }
                            if (dif_quadro6 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 5); valor_verificador += 1; }
                            if (dif_quadro7 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 6); valor_verificador += 1; }
                            if (dif_quadro8 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 7); valor_verificador += 1; }
                            if (dif_quadro9 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 8); valor_verificador += 1; }
                            if (dif_quadro10 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 9); valor_verificador += 1; }
                            if (dif_quadro11 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 10); valor_verificador += 1; }
                            if (dif_quadro12 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 11); valor_verificador += 1; }
                            if (dif_quadro13 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 12); valor_verificador += 1; }
                            if (dif_quadro14 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 13); valor_verificador += 1; }
                            if (dif_quadro15 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 14); valor_verificador += 1; }
                            if (dif_quadro16 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 15); valor_verificador += 1; }
                            if (dif_quadro17 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 16); valor_verificador += 1; }
                            if (dif_quadro18 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 17); valor_verificador += 1; }
                            if (dif_quadro19 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 18); valor_verificador += 1; }
                            if (dif_quadro20 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 19); valor_verificador += 1; }
                            if (dif_quadro21 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 20); valor_verificador += 1; }
                            if (dif_quadro22 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 21); valor_verificador += 1; }
                            if (dif_quadro23 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 22); valor_verificador += 1; }
                            if (dif_quadro24 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 23); valor_verificador += 1; }
                            if (dif_quadro25 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 24); valor_verificador += 1; }
                            if (dif_quadro26 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 25); valor_verificador += 1; }
                            if (dif_quadro27 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 26); valor_verificador += 1; }
                            if (dif_quadro28 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 27); valor_verificador += 1; }
                            if (dif_quadro29 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 28); valor_verificador += 1; }
                            if (dif_quadro30 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 29); valor_verificador += 1; }
                            if (dif_quadro31 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 30); valor_verificador += 1; }
                            if (dif_quadro32 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 31); valor_verificador += 1; }
                            if (dif_quadro33 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 32); valor_verificador += 1; }
                            if (dif_quadro34 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 33); valor_verificador += 1; }
                            if (dif_quadro35 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 34); valor_verificador += 1; }
                            if (dif_quadro36 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 35); valor_verificador += 1; }
                            if (dif_quadro37 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 36); valor_verificador += 1; }
                            if (dif_quadro38 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 37); valor_verificador += 1; }
                            if (dif_quadro39 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 38); valor_verificador += 1; }
                            if (dif_quadro40 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 39); valor_verificador += 1; }
                            if (dif_quadro41 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 40); valor_verificador += 1; }
                            if (dif_quadro42 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 41); valor_verificador += 1; }
                            if (dif_quadro43 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 42); valor_verificador += 1; }
                            if (dif_quadro44 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 43); valor_verificador += 1; }
                            if (dif_quadro45 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 44); valor_verificador += 1; }
                            if (dif_quadro46 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 45); valor_verificador += 1; }
                            if (dif_quadro47 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 46); valor_verificador += 1; }
                            if (dif_quadro48 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 47); valor_verificador += 1; }
                            if (dif_quadro49 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 48); valor_verificador += 1; }
                            if (dif_quadro50 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 49); valor_verificador += 1; }
                            if (dif_quadro51 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 50); valor_verificador += 1; }
                            if (dif_quadro52 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 51); valor_verificador += 1; }
                            if (dif_quadro53 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 52); valor_verificador += 1; }
                            if (dif_quadro54 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 53); valor_verificador += 1; }
                            if (dif_quadro55 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 54); valor_verificador += 1; }
                            if (dif_quadro56 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 55); valor_verificador += 1; }
                            if (dif_quadro57 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 56); valor_verificador += 1; }
                            if (dif_quadro58 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 57); valor_verificador += 1; }
                            if (dif_quadro59 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 58); valor_verificador += 1; }
                            if (dif_quadro60 > cor_de_corte) { valor_codigo += (long)Math.Pow(2, 59); valor_verificador += 1; }
                            if (dif_quadro61 > cor_de_corte) { valor_v += 1; }
                            if (dif_quadro62 > cor_de_corte) { valor_v += 2; }
                            if (dif_quadro63 > cor_de_corte) { valor_v += 4; }
                            if (dif_quadro64 > cor_de_corte) { valor_v += 8; }
                            if (dif_quadro65 > cor_de_corte) { valor_v += 16; }
                            if (dif_quadro66 > cor_de_corte) { valor_v += 32; }
                            if (dif_quadro67 > cor_de_corte) { valor_v += 64; }
                            if (dif_quadro68 > cor_de_corte) { valor_v += 128; }
                          
                            if (valor_v == valor_verificador)
                            {
                                TextWriter arquivo = new StreamWriter(@""+valor_codigo+".txt");
                                arquivo.WriteLine(respostas[0]);
                                arquivo.WriteLine(respostas[1]);
                                arquivo.WriteLine(respostas[2]);
                                arquivo.WriteLine(respostas[3]);
                                arquivo.WriteLine(respostas[4]);
                                arquivo.WriteLine(respostas[5]);
                                arquivo.WriteLine(respostas[6]);
                                arquivo.WriteLine(respostas[7]);
                                arquivo.WriteLine(respostas[8]);
                                arquivo.WriteLine(respostas[9]);
                                arquivo.Close();

                                Center = new AForge.IntPoint((int)valor_codigo, itens_identificados);
                            }

                            quadrado0[0] = new System.Drawing.PointF(tabela_codigo[0].X, tabela_codigo[0].Y);
                            quadrado0[1] = new System.Drawing.PointF(tabela_codigo[1].X, tabela_codigo[1].Y);
                            quadrado0[2] = new System.Drawing.PointF(tabela_codigo[18].X, tabela_codigo[18].Y);
                            quadrado0[3] = new System.Drawing.PointF(tabela_codigo[17].X, tabela_codigo[17].Y);
                            quadrado1[0] = new System.Drawing.PointF(tabela_codigo[1].X, tabela_codigo[1].Y);
                            quadrado1[1] = new System.Drawing.PointF(tabela_codigo[2].X, tabela_codigo[2].Y);
                            quadrado1[2] = new System.Drawing.PointF(tabela_codigo[19].X, tabela_codigo[19].Y);
                            quadrado1[3] = new System.Drawing.PointF(tabela_codigo[18].X, tabela_codigo[18].Y);
                            quadrado2[0] = new System.Drawing.PointF(tabela_codigo[2].X, tabela_codigo[2].Y);
                            quadrado2[1] = new System.Drawing.PointF(tabela_codigo[3].X, tabela_codigo[3].Y);
                            quadrado2[2] = new System.Drawing.PointF(tabela_codigo[20].X, tabela_codigo[20].Y);
                            quadrado2[3] = new System.Drawing.PointF(tabela_codigo[19].X, tabela_codigo[19].Y);
                            quadrado3[0] = new System.Drawing.PointF(tabela_codigo[3].X, tabela_codigo[3].Y);
                            quadrado3[1] = new System.Drawing.PointF(tabela_codigo[4].X, tabela_codigo[4].Y);
                            quadrado3[2] = new System.Drawing.PointF(tabela_codigo[21].X, tabela_codigo[21].Y);
                            quadrado3[3] = new System.Drawing.PointF(tabela_codigo[20].X, tabela_codigo[20].Y);
                            quadrado4[0] = new System.Drawing.PointF(tabela_codigo[4].X, tabela_codigo[4].Y);
                            quadrado4[1] = new System.Drawing.PointF(tabela_codigo[5].X, tabela_codigo[5].Y);
                            quadrado4[2] = new System.Drawing.PointF(tabela_codigo[22].X, tabela_codigo[22].Y);
                            quadrado4[3] = new System.Drawing.PointF(tabela_codigo[21].X, tabela_codigo[21].Y);
                            quadrado5[0] = new System.Drawing.PointF(tabela_codigo[5].X, tabela_codigo[5].Y);
                            quadrado5[1] = new System.Drawing.PointF(tabela_codigo[6].X, tabela_codigo[6].Y);
                            quadrado5[2] = new System.Drawing.PointF(tabela_codigo[23].X, tabela_codigo[23].Y);
                            quadrado5[3] = new System.Drawing.PointF(tabela_codigo[22].X, tabela_codigo[22].Y);
                            quadrado6[0] = new System.Drawing.PointF(tabela_codigo[6].X, tabela_codigo[6].Y);
                            quadrado6[1] = new System.Drawing.PointF(tabela_codigo[7].X, tabela_codigo[7].Y);
                            quadrado6[2] = new System.Drawing.PointF(tabela_codigo[24].X, tabela_codigo[24].Y);
                            quadrado6[3] = new System.Drawing.PointF(tabela_codigo[23].X, tabela_codigo[23].Y);
                            quadrado7[0] = new System.Drawing.PointF(tabela_codigo[7].X, tabela_codigo[7].Y);
                            quadrado7[1] = new System.Drawing.PointF(tabela_codigo[8].X, tabela_codigo[8].Y);
                            quadrado7[2] = new System.Drawing.PointF(tabela_codigo[25].X, tabela_codigo[25].Y);
                            quadrado7[3] = new System.Drawing.PointF(tabela_codigo[24].X, tabela_codigo[24].Y);
                            quadrado8[0] = new System.Drawing.PointF(tabela_codigo[8].X, tabela_codigo[8].Y);
                            quadrado8[1] = new System.Drawing.PointF(tabela_codigo[9].X, tabela_codigo[9].Y);
                            quadrado8[2] = new System.Drawing.PointF(tabela_codigo[26].X, tabela_codigo[26].Y);
                            quadrado8[3] = new System.Drawing.PointF(tabela_codigo[25].X, tabela_codigo[25].Y);
                            quadrado9[0] = new System.Drawing.PointF(tabela_codigo[9].X, tabela_codigo[9].Y);
                            quadrado9[1] = new System.Drawing.PointF(tabela_codigo[10].X, tabela_codigo[10].Y);
                            quadrado9[2] = new System.Drawing.PointF(tabela_codigo[27].X, tabela_codigo[27].Y);
                            quadrado9[3] = new System.Drawing.PointF(tabela_codigo[26].X, tabela_codigo[26].Y);
                            quadrado10[0] = new System.Drawing.PointF(tabela_codigo[10].X, tabela_codigo[10].Y);
                            quadrado10[1] = new System.Drawing.PointF(tabela_codigo[11].X, tabela_codigo[11].Y);
                            quadrado10[2] = new System.Drawing.PointF(tabela_codigo[28].X, tabela_codigo[28].Y);
                            quadrado10[3] = new System.Drawing.PointF(tabela_codigo[27].X, tabela_codigo[27].Y);
                            quadrado11[0] = new System.Drawing.PointF(tabela_codigo[11].X, tabela_codigo[11].Y);
                            quadrado11[1] = new System.Drawing.PointF(tabela_codigo[12].X, tabela_codigo[12].Y);
                            quadrado11[2] = new System.Drawing.PointF(tabela_codigo[29].X, tabela_codigo[29].Y);
                            quadrado11[3] = new System.Drawing.PointF(tabela_codigo[28].X, tabela_codigo[28].Y);
                            quadrado12[0] = new System.Drawing.PointF(tabela_codigo[12].X, tabela_codigo[12].Y);
                            quadrado12[1] = new System.Drawing.PointF(tabela_codigo[13].X, tabela_codigo[13].Y);
                            quadrado12[2] = new System.Drawing.PointF(tabela_codigo[30].X, tabela_codigo[30].Y);
                            quadrado12[3] = new System.Drawing.PointF(tabela_codigo[29].X, tabela_codigo[29].Y);
                            quadrado13[0] = new System.Drawing.PointF(tabela_codigo[13].X, tabela_codigo[13].Y);
                            quadrado13[1] = new System.Drawing.PointF(tabela_codigo[14].X, tabela_codigo[14].Y);
                            quadrado13[2] = new System.Drawing.PointF(tabela_codigo[31].X, tabela_codigo[31].Y);
                            quadrado13[3] = new System.Drawing.PointF(tabela_codigo[30].X, tabela_codigo[30].Y);
                            quadrado14[0] = new System.Drawing.PointF(tabela_codigo[14].X, tabela_codigo[14].Y);
                            quadrado14[1] = new System.Drawing.PointF(tabela_codigo[15].X, tabela_codigo[15].Y);
                            quadrado14[2] = new System.Drawing.PointF(tabela_codigo[32].X, tabela_codigo[32].Y);
                            quadrado14[3] = new System.Drawing.PointF(tabela_codigo[31].X, tabela_codigo[31].Y);
                            quadrado15[0] = new System.Drawing.PointF(tabela_codigo[15].X, tabela_codigo[15].Y);
                            quadrado15[1] = new System.Drawing.PointF(tabela_codigo[16].X, tabela_codigo[16].Y);
                            quadrado15[2] = new System.Drawing.PointF(tabela_codigo[33].X, tabela_codigo[33].Y);
                            quadrado15[3] = new System.Drawing.PointF(tabela_codigo[32].X, tabela_codigo[32].Y);
                            quadrado16[0] = new System.Drawing.PointF(tabela_codigo[16].X, tabela_codigo[16].Y);
                            quadrado16[1] = new System.Drawing.PointF(tabela_codigo[17].X, tabela_codigo[17].Y);
                            quadrado16[2] = new System.Drawing.PointF(tabela_codigo[34].X, tabela_codigo[34].Y);
                            quadrado16[3] = new System.Drawing.PointF(tabela_codigo[33].X, tabela_codigo[33].Y);
                            quadrado17[0] = new System.Drawing.PointF(tabela_codigo[17].X, tabela_codigo[17].Y);
                            quadrado17[1] = new System.Drawing.PointF(tabela_codigo[18].X, tabela_codigo[18].Y);
                            quadrado17[2] = new System.Drawing.PointF(tabela_codigo[35].X, tabela_codigo[35].Y);
                            quadrado17[3] = new System.Drawing.PointF(tabela_codigo[34].X, tabela_codigo[34].Y);
                            quadrado18[0] = new System.Drawing.PointF(tabela_codigo[18].X, tabela_codigo[18].Y);
                            quadrado18[1] = new System.Drawing.PointF(tabela_codigo[19].X, tabela_codigo[19].Y);
                            quadrado18[2] = new System.Drawing.PointF(tabela_codigo[36].X, tabela_codigo[36].Y);
                            quadrado18[3] = new System.Drawing.PointF(tabela_codigo[35].X, tabela_codigo[35].Y);
                            quadrado19[0] = new System.Drawing.PointF(tabela_codigo[19].X, tabela_codigo[19].Y);
                            quadrado19[1] = new System.Drawing.PointF(tabela_codigo[20].X, tabela_codigo[20].Y);
                            quadrado19[2] = new System.Drawing.PointF(tabela_codigo[37].X, tabela_codigo[37].Y);
                            quadrado19[3] = new System.Drawing.PointF(tabela_codigo[36].X, tabela_codigo[36].Y);
                            quadrado20[0] = new System.Drawing.PointF(tabela_codigo[20].X, tabela_codigo[20].Y);
                            quadrado20[1] = new System.Drawing.PointF(tabela_codigo[21].X, tabela_codigo[21].Y);
                            quadrado20[2] = new System.Drawing.PointF(tabela_codigo[38].X, tabela_codigo[38].Y);
                            quadrado20[3] = new System.Drawing.PointF(tabela_codigo[37].X, tabela_codigo[37].Y);
                            quadrado21[0] = new System.Drawing.PointF(tabela_codigo[21].X, tabela_codigo[21].Y);
                            quadrado21[1] = new System.Drawing.PointF(tabela_codigo[22].X, tabela_codigo[22].Y);
                            quadrado21[2] = new System.Drawing.PointF(tabela_codigo[39].X, tabela_codigo[39].Y);
                            quadrado21[3] = new System.Drawing.PointF(tabela_codigo[38].X, tabela_codigo[38].Y);
                            quadrado22[0] = new System.Drawing.PointF(tabela_codigo[22].X, tabela_codigo[22].Y);
                            quadrado22[1] = new System.Drawing.PointF(tabela_codigo[23].X, tabela_codigo[23].Y);
                            quadrado22[2] = new System.Drawing.PointF(tabela_codigo[40].X, tabela_codigo[40].Y);
                            quadrado22[3] = new System.Drawing.PointF(tabela_codigo[39].X, tabela_codigo[39].Y);
                            quadrado23[0] = new System.Drawing.PointF(tabela_codigo[23].X, tabela_codigo[23].Y);
                            quadrado23[1] = new System.Drawing.PointF(tabela_codigo[24].X, tabela_codigo[24].Y);
                            quadrado23[2] = new System.Drawing.PointF(tabela_codigo[41].X, tabela_codigo[41].Y);
                            quadrado23[3] = new System.Drawing.PointF(tabela_codigo[40].X, tabela_codigo[40].Y);
                            quadrado24[0] = new System.Drawing.PointF(tabela_codigo[24].X, tabela_codigo[24].Y);
                            quadrado24[1] = new System.Drawing.PointF(tabela_codigo[25].X, tabela_codigo[25].Y);
                            quadrado24[2] = new System.Drawing.PointF(tabela_codigo[42].X, tabela_codigo[42].Y);
                            quadrado24[3] = new System.Drawing.PointF(tabela_codigo[41].X, tabela_codigo[41].Y);
                            quadrado25[0] = new System.Drawing.PointF(tabela_codigo[25].X, tabela_codigo[25].Y);
                            quadrado25[1] = new System.Drawing.PointF(tabela_codigo[26].X, tabela_codigo[26].Y);
                            quadrado25[2] = new System.Drawing.PointF(tabela_codigo[43].X, tabela_codigo[43].Y);
                            quadrado25[3] = new System.Drawing.PointF(tabela_codigo[42].X, tabela_codigo[42].Y);
                            quadrado26[0] = new System.Drawing.PointF(tabela_codigo[26].X, tabela_codigo[26].Y);
                            quadrado26[1] = new System.Drawing.PointF(tabela_codigo[27].X, tabela_codigo[27].Y);
                            quadrado26[2] = new System.Drawing.PointF(tabela_codigo[44].X, tabela_codigo[44].Y);
                            quadrado26[3] = new System.Drawing.PointF(tabela_codigo[43].X, tabela_codigo[43].Y);
                            quadrado27[0] = new System.Drawing.PointF(tabela_codigo[27].X, tabela_codigo[27].Y);
                            quadrado27[1] = new System.Drawing.PointF(tabela_codigo[28].X, tabela_codigo[28].Y);
                            quadrado27[2] = new System.Drawing.PointF(tabela_codigo[45].X, tabela_codigo[45].Y);
                            quadrado27[3] = new System.Drawing.PointF(tabela_codigo[44].X, tabela_codigo[44].Y);
                            quadrado28[0] = new System.Drawing.PointF(tabela_codigo[28].X, tabela_codigo[28].Y);
                            quadrado28[1] = new System.Drawing.PointF(tabela_codigo[29].X, tabela_codigo[29].Y);
                            quadrado28[2] = new System.Drawing.PointF(tabela_codigo[46].X, tabela_codigo[46].Y);
                            quadrado28[3] = new System.Drawing.PointF(tabela_codigo[45].X, tabela_codigo[45].Y);
                            quadrado29[0] = new System.Drawing.PointF(tabela_codigo[29].X, tabela_codigo[29].Y);
                            quadrado29[1] = new System.Drawing.PointF(tabela_codigo[30].X, tabela_codigo[30].Y);
                            quadrado29[2] = new System.Drawing.PointF(tabela_codigo[47].X, tabela_codigo[47].Y);
                            quadrado29[3] = new System.Drawing.PointF(tabela_codigo[46].X, tabela_codigo[46].Y);
                            quadrado30[0] = new System.Drawing.PointF(tabela_codigo[30].X, tabela_codigo[30].Y);
                            quadrado30[1] = new System.Drawing.PointF(tabela_codigo[31].X, tabela_codigo[31].Y);
                            quadrado30[2] = new System.Drawing.PointF(tabela_codigo[48].X, tabela_codigo[48].Y);
                            quadrado30[3] = new System.Drawing.PointF(tabela_codigo[47].X, tabela_codigo[47].Y);
                            quadrado31[0] = new System.Drawing.PointF(tabela_codigo[31].X, tabela_codigo[31].Y);
                            quadrado31[1] = new System.Drawing.PointF(tabela_codigo[32].X, tabela_codigo[32].Y);
                            quadrado31[2] = new System.Drawing.PointF(tabela_codigo[49].X, tabela_codigo[49].Y);
                            quadrado31[3] = new System.Drawing.PointF(tabela_codigo[48].X, tabela_codigo[48].Y);
                            quadrado32[0] = new System.Drawing.PointF(tabela_codigo[32].X, tabela_codigo[32].Y);
                            quadrado32[1] = new System.Drawing.PointF(tabela_codigo[33].X, tabela_codigo[33].Y);
                            quadrado32[2] = new System.Drawing.PointF(tabela_codigo[50].X, tabela_codigo[50].Y);
                            quadrado32[3] = new System.Drawing.PointF(tabela_codigo[49].X, tabela_codigo[49].Y);
                            quadrado33[0] = new System.Drawing.PointF(tabela_codigo[33].X, tabela_codigo[33].Y);
                            quadrado33[1] = new System.Drawing.PointF(tabela_codigo[34].X, tabela_codigo[34].Y);
                            quadrado33[2] = new System.Drawing.PointF(tabela_codigo[51].X, tabela_codigo[51].Y);
                            quadrado33[3] = new System.Drawing.PointF(tabela_codigo[50].X, tabela_codigo[50].Y);
                            quadrado34[0] = new System.Drawing.PointF(tabela_codigo[34].X, tabela_codigo[34].Y);
                            quadrado34[1] = new System.Drawing.PointF(tabela_codigo[35].X, tabela_codigo[35].Y);
                            quadrado34[2] = new System.Drawing.PointF(tabela_codigo[52].X, tabela_codigo[52].Y);
                            quadrado34[3] = new System.Drawing.PointF(tabela_codigo[51].X, tabela_codigo[51].Y);
                            quadrado35[0] = new System.Drawing.PointF(tabela_codigo[35].X, tabela_codigo[35].Y);
                            quadrado35[1] = new System.Drawing.PointF(tabela_codigo[36].X, tabela_codigo[36].Y);
                            quadrado35[2] = new System.Drawing.PointF(tabela_codigo[53].X, tabela_codigo[53].Y);
                            quadrado35[3] = new System.Drawing.PointF(tabela_codigo[52].X, tabela_codigo[52].Y);
                            quadrado36[0] = new System.Drawing.PointF(tabela_codigo[36].X, tabela_codigo[36].Y);
                            quadrado36[1] = new System.Drawing.PointF(tabela_codigo[37].X, tabela_codigo[37].Y);
                            quadrado36[2] = new System.Drawing.PointF(tabela_codigo[54].X, tabela_codigo[54].Y);
                            quadrado36[3] = new System.Drawing.PointF(tabela_codigo[53].X, tabela_codigo[53].Y);
                            quadrado37[0] = new System.Drawing.PointF(tabela_codigo[37].X, tabela_codigo[37].Y);
                            quadrado37[1] = new System.Drawing.PointF(tabela_codigo[38].X, tabela_codigo[38].Y);
                            quadrado37[2] = new System.Drawing.PointF(tabela_codigo[55].X, tabela_codigo[55].Y);
                            quadrado37[3] = new System.Drawing.PointF(tabela_codigo[54].X, tabela_codigo[54].Y);
                            quadrado38[0] = new System.Drawing.PointF(tabela_codigo[38].X, tabela_codigo[38].Y);
                            quadrado38[1] = new System.Drawing.PointF(tabela_codigo[39].X, tabela_codigo[39].Y);
                            quadrado38[2] = new System.Drawing.PointF(tabela_codigo[56].X, tabela_codigo[56].Y);
                            quadrado38[3] = new System.Drawing.PointF(tabela_codigo[55].X, tabela_codigo[55].Y);
                            quadrado39[0] = new System.Drawing.PointF(tabela_codigo[39].X, tabela_codigo[39].Y);
                            quadrado39[1] = new System.Drawing.PointF(tabela_codigo[40].X, tabela_codigo[40].Y);
                            quadrado39[2] = new System.Drawing.PointF(tabela_codigo[57].X, tabela_codigo[57].Y);
                            quadrado39[3] = new System.Drawing.PointF(tabela_codigo[56].X, tabela_codigo[56].Y);
                            quadrado40[0] = new System.Drawing.PointF(tabela_codigo[40].X, tabela_codigo[40].Y);
                            quadrado40[1] = new System.Drawing.PointF(tabela_codigo[41].X, tabela_codigo[41].Y);
                            quadrado40[2] = new System.Drawing.PointF(tabela_codigo[58].X, tabela_codigo[58].Y);
                            quadrado40[3] = new System.Drawing.PointF(tabela_codigo[57].X, tabela_codigo[57].Y);
                            quadrado41[0] = new System.Drawing.PointF(tabela_codigo[41].X, tabela_codigo[41].Y);
                            quadrado41[1] = new System.Drawing.PointF(tabela_codigo[42].X, tabela_codigo[42].Y);
                            quadrado41[2] = new System.Drawing.PointF(tabela_codigo[59].X, tabela_codigo[59].Y);
                            quadrado41[3] = new System.Drawing.PointF(tabela_codigo[58].X, tabela_codigo[58].Y);
                            quadrado42[0] = new System.Drawing.PointF(tabela_codigo[42].X, tabela_codigo[42].Y);
                            quadrado42[1] = new System.Drawing.PointF(tabela_codigo[43].X, tabela_codigo[43].Y);
                            quadrado42[2] = new System.Drawing.PointF(tabela_codigo[60].X, tabela_codigo[60].Y);
                            quadrado42[3] = new System.Drawing.PointF(tabela_codigo[59].X, tabela_codigo[59].Y);
                            quadrado43[0] = new System.Drawing.PointF(tabela_codigo[43].X, tabela_codigo[43].Y);
                            quadrado43[1] = new System.Drawing.PointF(tabela_codigo[44].X, tabela_codigo[44].Y);
                            quadrado43[2] = new System.Drawing.PointF(tabela_codigo[61].X, tabela_codigo[61].Y);
                            quadrado43[3] = new System.Drawing.PointF(tabela_codigo[60].X, tabela_codigo[60].Y);
                            quadrado44[0] = new System.Drawing.PointF(tabela_codigo[44].X, tabela_codigo[44].Y);
                            quadrado44[1] = new System.Drawing.PointF(tabela_codigo[45].X, tabela_codigo[45].Y);
                            quadrado44[2] = new System.Drawing.PointF(tabela_codigo[62].X, tabela_codigo[62].Y);
                            quadrado44[3] = new System.Drawing.PointF(tabela_codigo[61].X, tabela_codigo[61].Y);
                            quadrado45[0] = new System.Drawing.PointF(tabela_codigo[45].X, tabela_codigo[45].Y);
                            quadrado45[1] = new System.Drawing.PointF(tabela_codigo[46].X, tabela_codigo[46].Y);
                            quadrado45[2] = new System.Drawing.PointF(tabela_codigo[63].X, tabela_codigo[63].Y);
                            quadrado45[3] = new System.Drawing.PointF(tabela_codigo[62].X, tabela_codigo[62].Y);
                            quadrado46[0] = new System.Drawing.PointF(tabela_codigo[46].X, tabela_codigo[46].Y);
                            quadrado46[1] = new System.Drawing.PointF(tabela_codigo[47].X, tabela_codigo[47].Y);
                            quadrado46[2] = new System.Drawing.PointF(tabela_codigo[64].X, tabela_codigo[64].Y);
                            quadrado46[3] = new System.Drawing.PointF(tabela_codigo[63].X, tabela_codigo[63].Y);
                            quadrado47[0] = new System.Drawing.PointF(tabela_codigo[47].X, tabela_codigo[47].Y);
                            quadrado47[1] = new System.Drawing.PointF(tabela_codigo[48].X, tabela_codigo[48].Y);
                            quadrado47[2] = new System.Drawing.PointF(tabela_codigo[65].X, tabela_codigo[65].Y);
                            quadrado47[3] = new System.Drawing.PointF(tabela_codigo[64].X, tabela_codigo[64].Y);
                            quadrado48[0] = new System.Drawing.PointF(tabela_codigo[48].X, tabela_codigo[48].Y);
                            quadrado48[1] = new System.Drawing.PointF(tabela_codigo[49].X, tabela_codigo[49].Y);
                            quadrado48[2] = new System.Drawing.PointF(tabela_codigo[66].X, tabela_codigo[66].Y);
                            quadrado48[3] = new System.Drawing.PointF(tabela_codigo[65].X, tabela_codigo[65].Y);
                            quadrado49[0] = new System.Drawing.PointF(tabela_codigo[49].X, tabela_codigo[49].Y);
                            quadrado49[1] = new System.Drawing.PointF(tabela_codigo[50].X, tabela_codigo[50].Y);
                            quadrado49[2] = new System.Drawing.PointF(tabela_codigo[67].X, tabela_codigo[67].Y);
                            quadrado49[3] = new System.Drawing.PointF(tabela_codigo[66].X, tabela_codigo[66].Y);
                            quadrado50[0] = new System.Drawing.PointF(tabela_codigo[50].X, tabela_codigo[50].Y);
                            quadrado50[1] = new System.Drawing.PointF(tabela_codigo[51].X, tabela_codigo[51].Y);
                            quadrado50[2] = new System.Drawing.PointF(tabela_codigo[67].X, tabela_codigo[67].Y);
                            quadrado50[3] = new System.Drawing.PointF(tabela_codigo[66].X, tabela_codigo[66].Y);
                            quadrado51[0] = new System.Drawing.PointF(tabela_codigo[51].X, tabela_codigo[51].Y);
                            quadrado51[1] = new System.Drawing.PointF(tabela_codigo[52].X, tabela_codigo[52].Y);
                            quadrado51[2] = new System.Drawing.PointF(tabela_codigo[69].X, tabela_codigo[69].Y);
                            quadrado51[3] = new System.Drawing.PointF(tabela_codigo[68].X, tabela_codigo[68].Y);
                            quadrado52[0] = new System.Drawing.PointF(tabela_codigo[52].X, tabela_codigo[52].Y);
                            quadrado52[1] = new System.Drawing.PointF(tabela_codigo[53].X, tabela_codigo[53].Y);
                            quadrado52[2] = new System.Drawing.PointF(tabela_codigo[70].X, tabela_codigo[70].Y);
                            quadrado52[3] = new System.Drawing.PointF(tabela_codigo[69].X, tabela_codigo[69].Y);
                            quadrado53[0] = new System.Drawing.PointF(tabela_codigo[53].X, tabela_codigo[53].Y);
                            quadrado53[1] = new System.Drawing.PointF(tabela_codigo[54].X, tabela_codigo[54].Y);
                            quadrado53[2] = new System.Drawing.PointF(tabela_codigo[71].X, tabela_codigo[71].Y);
                            quadrado53[3] = new System.Drawing.PointF(tabela_codigo[70].X, tabela_codigo[70].Y);
                            quadrado54[0] = new System.Drawing.PointF(tabela_codigo[54].X, tabela_codigo[54].Y);
                            quadrado54[1] = new System.Drawing.PointF(tabela_codigo[55].X, tabela_codigo[55].Y);
                            quadrado54[2] = new System.Drawing.PointF(tabela_codigo[72].X, tabela_codigo[72].Y);
                            quadrado54[3] = new System.Drawing.PointF(tabela_codigo[71].X, tabela_codigo[71].Y);
                            quadrado55[0] = new System.Drawing.PointF(tabela_codigo[55].X, tabela_codigo[55].Y);
                            quadrado55[1] = new System.Drawing.PointF(tabela_codigo[56].X, tabela_codigo[56].Y);
                            quadrado55[2] = new System.Drawing.PointF(tabela_codigo[73].X, tabela_codigo[73].Y);
                            quadrado55[3] = new System.Drawing.PointF(tabela_codigo[72].X, tabela_codigo[72].Y);
                            quadrado56[0] = new System.Drawing.PointF(tabela_codigo[56].X, tabela_codigo[56].Y);
                            quadrado56[1] = new System.Drawing.PointF(tabela_codigo[57].X, tabela_codigo[57].Y);
                            quadrado56[2] = new System.Drawing.PointF(tabela_codigo[74].X, tabela_codigo[74].Y);
                            quadrado56[3] = new System.Drawing.PointF(tabela_codigo[73].X, tabela_codigo[73].Y);
                            quadrado57[0] = new System.Drawing.PointF(tabela_codigo[57].X, tabela_codigo[57].Y);
                            quadrado57[1] = new System.Drawing.PointF(tabela_codigo[58].X, tabela_codigo[58].Y);
                            quadrado57[2] = new System.Drawing.PointF(tabela_codigo[75].X, tabela_codigo[75].Y);
                            quadrado57[3] = new System.Drawing.PointF(tabela_codigo[74].X, tabela_codigo[74].Y);
                            quadrado58[0] = new System.Drawing.PointF(tabela_codigo[58].X, tabela_codigo[58].Y);
                            quadrado58[1] = new System.Drawing.PointF(tabela_codigo[59].X, tabela_codigo[59].Y);
                            quadrado58[2] = new System.Drawing.PointF(tabela_codigo[76].X, tabela_codigo[76].Y);
                            quadrado58[3] = new System.Drawing.PointF(tabela_codigo[75].X, tabela_codigo[75].Y);
                            quadrado59[0] = new System.Drawing.PointF(tabela_codigo[59].X, tabela_codigo[59].Y);
                            quadrado59[1] = new System.Drawing.PointF(tabela_codigo[60].X, tabela_codigo[60].Y);
                            quadrado59[2] = new System.Drawing.PointF(tabela_codigo[77].X, tabela_codigo[77].Y);
                            quadrado59[3] = new System.Drawing.PointF(tabela_codigo[76].X, tabela_codigo[76].Y);
                            quadrado60[0] = new System.Drawing.PointF(tabela_codigo[60].X, tabela_codigo[60].Y);
                            quadrado60[1] = new System.Drawing.PointF(tabela_codigo[61].X, tabela_codigo[61].Y);
                            quadrado60[2] = new System.Drawing.PointF(tabela_codigo[78].X, tabela_codigo[78].Y);
                            quadrado60[3] = new System.Drawing.PointF(tabela_codigo[77].X, tabela_codigo[77].Y);
                            quadrado61[0] = new System.Drawing.PointF(tabela_codigo[61].X, tabela_codigo[61].Y);
                            quadrado61[1] = new System.Drawing.PointF(tabela_codigo[62].X, tabela_codigo[62].Y);
                            quadrado61[2] = new System.Drawing.PointF(tabela_codigo[79].X, tabela_codigo[79].Y);
                            quadrado61[3] = new System.Drawing.PointF(tabela_codigo[78].X, tabela_codigo[78].Y);
                            quadrado62[0] = new System.Drawing.PointF(tabela_codigo[62].X, tabela_codigo[62].Y);
                            quadrado62[1] = new System.Drawing.PointF(tabela_codigo[63].X, tabela_codigo[63].Y);
                            quadrado62[2] = new System.Drawing.PointF(tabela_codigo[80].X, tabela_codigo[80].Y);
                            quadrado62[3] = new System.Drawing.PointF(tabela_codigo[79].X, tabela_codigo[79].Y);
                            quadrado63[0] = new System.Drawing.PointF(tabela_codigo[63].X, tabela_codigo[63].Y);
                            quadrado63[1] = new System.Drawing.PointF(tabela_codigo[64].X, tabela_codigo[64].Y);
                            quadrado63[2] = new System.Drawing.PointF(tabela_codigo[81].X, tabela_codigo[81].Y);
                            quadrado63[3] = new System.Drawing.PointF(tabela_codigo[80].X, tabela_codigo[80].Y);
                            quadrado64[0] = new System.Drawing.PointF(tabela_codigo[64].X, tabela_codigo[64].Y);
                            quadrado64[1] = new System.Drawing.PointF(tabela_codigo[65].X, tabela_codigo[65].Y);
                            quadrado64[2] = new System.Drawing.PointF(tabela_codigo[82].X, tabela_codigo[82].Y);
                            quadrado64[3] = new System.Drawing.PointF(tabela_codigo[81].X, tabela_codigo[81].Y);
                            quadrado65[0] = new System.Drawing.PointF(tabela_codigo[65].X, tabela_codigo[65].Y);
                            quadrado65[1] = new System.Drawing.PointF(tabela_codigo[66].X, tabela_codigo[66].Y);
                            quadrado65[2] = new System.Drawing.PointF(tabela_codigo[83].X, tabela_codigo[83].Y);
                            quadrado65[3] = new System.Drawing.PointF(tabela_codigo[82].X, tabela_codigo[82].Y);
                            quadrado66[0] = new System.Drawing.PointF(tabela_codigo[66].X, tabela_codigo[66].Y);
                            quadrado66[1] = new System.Drawing.PointF(tabela_codigo[67].X, tabela_codigo[67].Y);
                            quadrado66[2] = new System.Drawing.PointF(tabela_codigo[84].X, tabela_codigo[84].Y);
                            quadrado66[3] = new System.Drawing.PointF(tabela_codigo[83].X, tabela_codigo[83].Y);
                            quadrado67[0] = new System.Drawing.PointF(tabela_codigo[67].X, tabela_codigo[67].Y);
                            quadrado67[1] = new System.Drawing.PointF(tabela_codigo[68].X, tabela_codigo[68].Y);
                            quadrado67[2] = new System.Drawing.PointF(tabela_codigo[85].X, tabela_codigo[85].Y);
                            quadrado67[3] = new System.Drawing.PointF(tabela_codigo[84].X, tabela_codigo[84].Y);
                            quadrado68[0] = new System.Drawing.PointF(tabela_codigo[68].X, tabela_codigo[68].Y);
                            quadrado68[1] = new System.Drawing.PointF(tabela_codigo[69].X, tabela_codigo[69].Y);
                            quadrado68[2] = new System.Drawing.PointF(tabela_codigo[86].X, tabela_codigo[86].Y);
                            quadrado68[3] = new System.Drawing.PointF(tabela_codigo[85].X, tabela_codigo[85].Y);
                            quadrado69[0] = new System.Drawing.PointF(tabela_codigo[69].X, tabela_codigo[69].Y);
                            quadrado69[1] = new System.Drawing.PointF(tabela_codigo[70].X, tabela_codigo[70].Y);
                            quadrado69[2] = new System.Drawing.PointF(tabela_codigo[87].X, tabela_codigo[87].Y);
                            quadrado69[3] = new System.Drawing.PointF(tabela_codigo[86].X, tabela_codigo[86].Y);
                            quadrado70[0] = new System.Drawing.PointF(tabela_codigo[70].X, tabela_codigo[70].Y);
                            quadrado70[1] = new System.Drawing.PointF(tabela_codigo[71].X, tabela_codigo[71].Y);
                            quadrado70[2] = new System.Drawing.PointF(tabela_codigo[88].X, tabela_codigo[88].Y);
                            quadrado70[3] = new System.Drawing.PointF(tabela_codigo[87].X, tabela_codigo[87].Y);
                            quadrado71[0] = new System.Drawing.PointF(tabela_codigo[71].X, tabela_codigo[71].Y);
                            quadrado71[1] = new System.Drawing.PointF(tabela_codigo[72].X, tabela_codigo[72].Y);
                            quadrado71[2] = new System.Drawing.PointF(tabela_codigo[89].X, tabela_codigo[89].Y);
                            quadrado71[3] = new System.Drawing.PointF(tabela_codigo[88].X, tabela_codigo[88].Y);
                            quadrado72[0] = new System.Drawing.PointF(tabela_codigo[72].X, tabela_codigo[72].Y);
                            quadrado72[1] = new System.Drawing.PointF(tabela_codigo[73].X, tabela_codigo[73].Y);
                            quadrado72[2] = new System.Drawing.PointF(tabela_codigo[90].X, tabela_codigo[90].Y);
                            quadrado72[3] = new System.Drawing.PointF(tabela_codigo[89].X, tabela_codigo[89].Y);
                            quadrado73[0] = new System.Drawing.PointF(tabela_codigo[73].X, tabela_codigo[73].Y);
                            quadrado73[1] = new System.Drawing.PointF(tabela_codigo[74].X, tabela_codigo[74].Y);
                            quadrado73[2] = new System.Drawing.PointF(tabela_codigo[91].X, tabela_codigo[91].Y);
                            quadrado73[3] = new System.Drawing.PointF(tabela_codigo[90].X, tabela_codigo[90].Y);
                            quadrado74[0] = new System.Drawing.PointF(tabela_codigo[74].X, tabela_codigo[74].Y);
                            quadrado74[1] = new System.Drawing.PointF(tabela_codigo[75].X, tabela_codigo[75].Y);
                            quadrado74[2] = new System.Drawing.PointF(tabela_codigo[92].X, tabela_codigo[92].Y);
                            quadrado74[3] = new System.Drawing.PointF(tabela_codigo[91].X, tabela_codigo[91].Y);
                            quadrado75[0] = new System.Drawing.PointF(tabela_codigo[75].X, tabela_codigo[75].Y);
                            quadrado75[1] = new System.Drawing.PointF(tabela_codigo[76].X, tabela_codigo[76].Y);
                            quadrado75[2] = new System.Drawing.PointF(tabela_codigo[93].X, tabela_codigo[93].Y);
                            quadrado75[3] = new System.Drawing.PointF(tabela_codigo[92].X, tabela_codigo[92].Y);
                            quadrado76[0] = new System.Drawing.PointF(tabela_codigo[76].X, tabela_codigo[76].Y);
                            quadrado76[1] = new System.Drawing.PointF(tabela_codigo[77].X, tabela_codigo[77].Y);
                            quadrado76[2] = new System.Drawing.PointF(tabela_codigo[94].X, tabela_codigo[94].Y);
                            quadrado76[3] = new System.Drawing.PointF(tabela_codigo[93].X, tabela_codigo[93].Y);
                            quadrado77[0] = new System.Drawing.PointF(tabela_codigo[77].X, tabela_codigo[77].Y);
                            quadrado77[1] = new System.Drawing.PointF(tabela_codigo[78].X, tabela_codigo[78].Y);
                            quadrado77[2] = new System.Drawing.PointF(tabela_codigo[95].X, tabela_codigo[95].Y);
                            quadrado77[3] = new System.Drawing.PointF(tabela_codigo[94].X, tabela_codigo[94].Y);
                            quadrado78[0] = new System.Drawing.PointF(tabela_codigo[78].X, tabela_codigo[78].Y);
                            quadrado78[1] = new System.Drawing.PointF(tabela_codigo[79].X, tabela_codigo[79].Y);
                            quadrado78[2] = new System.Drawing.PointF(tabela_codigo[96].X, tabela_codigo[96].Y);
                            quadrado78[3] = new System.Drawing.PointF(tabela_codigo[95].X, tabela_codigo[95].Y);
                            quadrado79[0] = new System.Drawing.PointF(tabela_codigo[79].X, tabela_codigo[79].Y);
                            quadrado79[1] = new System.Drawing.PointF(tabela_codigo[80].X, tabela_codigo[80].Y);
                            quadrado79[2] = new System.Drawing.PointF(tabela_codigo[97].X, tabela_codigo[97].Y);
                            quadrado79[3] = new System.Drawing.PointF(tabela_codigo[96].X, tabela_codigo[96].Y);
                            quadrado80[0] = new System.Drawing.PointF(tabela_codigo[80].X, tabela_codigo[80].Y);
                            quadrado80[1] = new System.Drawing.PointF(tabela_codigo[81].X, tabela_codigo[81].Y);
                            quadrado80[2] = new System.Drawing.PointF(tabela_codigo[98].X, tabela_codigo[98].Y);
                            quadrado80[3] = new System.Drawing.PointF(tabela_codigo[97].X, tabela_codigo[97].Y);
                            quadrado81[0] = new System.Drawing.PointF(tabela_codigo[81].X, tabela_codigo[81].Y);
                            quadrado81[1] = new System.Drawing.PointF(tabela_codigo[82].X, tabela_codigo[82].Y);
                            quadrado81[2] = new System.Drawing.PointF(tabela_codigo[99].X, tabela_codigo[99].Y);
                            quadrado81[3] = new System.Drawing.PointF(tabela_codigo[98].X, tabela_codigo[98].Y);
                            quadrado82[0] = new System.Drawing.PointF(tabela_codigo[82].X, tabela_codigo[82].Y);
                            quadrado82[1] = new System.Drawing.PointF(tabela_codigo[83].X, tabela_codigo[83].Y);
                            quadrado82[2] = new System.Drawing.PointF(tabela_codigo[100].X, tabela_codigo[100].Y);
                            quadrado82[3] = new System.Drawing.PointF(tabela_codigo[99].X, tabela_codigo[99].Y);
                            quadrado83[0] = new System.Drawing.PointF(tabela_codigo[83].X, tabela_codigo[83].Y);
                            quadrado83[1] = new System.Drawing.PointF(tabela_codigo[84].X, tabela_codigo[84].Y);
                            quadrado83[2] = new System.Drawing.PointF(tabela_codigo[101].X, tabela_codigo[101].Y);
                            quadrado83[3] = new System.Drawing.PointF(tabela_codigo[100].X, tabela_codigo[100].Y);

                            g.DrawPolygon(whitePen, quadrado0);
                            g.DrawPolygon(whitePen, quadrado1);
                            g.DrawPolygon(whitePen, quadrado2);
                            g.DrawPolygon(whitePen, quadrado3);
                            g.DrawPolygon(whitePen, quadrado4);
                            g.DrawPolygon(whitePen, quadrado5);
                            g.DrawPolygon(whitePen, quadrado6);
                            g.DrawPolygon(whitePen, quadrado7);
                            g.DrawPolygon(whitePen, quadrado8);
                            g.DrawPolygon(whitePen, quadrado9);
                            g.DrawPolygon(whitePen, quadrado10);
                            g.DrawPolygon(whitePen, quadrado11);
                            g.DrawPolygon(whitePen, quadrado12);
                            g.DrawPolygon(whitePen, quadrado13);
                            g.DrawPolygon(whitePen, quadrado14);
                            g.DrawPolygon(whitePen, quadrado15);

                            g.DrawPolygon(whitePen, quadrado17);
                            g.DrawPolygon(whitePen, quadrado18);
                            g.DrawPolygon(whitePen, quadrado19);
                            g.DrawPolygon(whitePen, quadrado20);
                            g.DrawPolygon(whitePen, quadrado21);
                            g.DrawPolygon(whitePen, quadrado22);
                            g.DrawPolygon(whitePen, quadrado23);
                            g.DrawPolygon(whitePen, quadrado24);
                            g.DrawPolygon(whitePen, quadrado25);
                            g.DrawPolygon(whitePen, quadrado26);
                            g.DrawPolygon(whitePen, quadrado27);
                            g.DrawPolygon(whitePen, quadrado28);
                            g.DrawPolygon(whitePen, quadrado29);
                            g.DrawPolygon(whitePen, quadrado30);
                            g.DrawPolygon(whitePen, quadrado31);
                            g.DrawPolygon(whitePen, quadrado32);
                            
                            g.DrawPolygon(whitePen, quadrado34);
                            g.DrawPolygon(whitePen, quadrado35);
                            g.DrawPolygon(whitePen, quadrado36);
                            g.DrawPolygon(whitePen, quadrado37);
                            g.DrawPolygon(whitePen, quadrado38);
                            g.DrawPolygon(whitePen, quadrado39);
                            g.DrawPolygon(whitePen, quadrado40);
                            g.DrawPolygon(whitePen, quadrado41);
                            g.DrawPolygon(whitePen, quadrado42);
                            g.DrawPolygon(whitePen, quadrado43);
                            g.DrawPolygon(whitePen, quadrado44);
                            g.DrawPolygon(whitePen, quadrado45);
                            g.DrawPolygon(whitePen, quadrado46);
                            g.DrawPolygon(whitePen, quadrado47);
                            g.DrawPolygon(whitePen, quadrado48);
                            g.DrawPolygon(whitePen, quadrado49);
                            
                            g.DrawPolygon(whitePen, quadrado51);
                            g.DrawPolygon(whitePen, quadrado52);
                            g.DrawPolygon(whitePen, quadrado53);
                            g.DrawPolygon(whitePen, quadrado54);
                            g.DrawPolygon(whitePen, quadrado55);
                            g.DrawPolygon(whitePen, quadrado56);
                            g.DrawPolygon(whitePen, quadrado57);
                            g.DrawPolygon(whitePen, quadrado58);
                            g.DrawPolygon(whitePen, quadrado59);
                            g.DrawPolygon(whitePen, quadrado60);
                            g.DrawPolygon(whitePen, quadrado61);
                            g.DrawPolygon(whitePen, quadrado62);
                            g.DrawPolygon(whitePen, quadrado63);
                            g.DrawPolygon(whitePen, quadrado64);
                            g.DrawPolygon(whitePen, quadrado65);
                            g.DrawPolygon(whitePen, quadrado66);
                            
                            g.DrawPolygon(whitePen, quadrado68);
                            g.DrawPolygon(whitePen, quadrado69);
                            g.DrawPolygon(whitePen, quadrado70);
                            g.DrawPolygon(whitePen, quadrado71);
                            g.DrawPolygon(whitePen, quadrado72);
                            g.DrawPolygon(whitePen, quadrado73);
                            g.DrawPolygon(whitePen, quadrado74);
                            g.DrawPolygon(whitePen, quadrado75);
                            g.DrawPolygon(whitePen, quadrado76);
                            g.DrawPolygon(whitePen, quadrado77);
                            g.DrawPolygon(whitePen, quadrado78);
                            g.DrawPolygon(whitePen, quadrado79);
                            g.DrawPolygon(whitePen, quadrado80);
                            g.DrawPolygon(whitePen, quadrado81);
                            g.DrawPolygon(whitePen, quadrado82);
                            g.DrawPolygon(whitePen, quadrado83);
                            g.DrawLine(penIn, p10, p11);
                            g.DrawLine(penIn, p12, p13);
                     }
                     catch { }                      
                        }
                    }
                }
            }
        }
        greenPen.Dispose();
        penIn.Dispose();
        whitePen.Dispose();
        NewTargetPosition(Center, image);
        g.Dispose();
    }
}
