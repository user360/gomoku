using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gomoku_project
{
    public class Heuristic
    { 
        private static Box.State ownSTT;
        private static Box.State oppSTT;

        # region temp
        private String Reverse(String other)
        {
            char[] array = other.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
        private static int[] attackScore = new int[6] { 0, 20, 300, 1500, 8000, 40000 };
        private static int[] defenseScore = new int[6] { 0, 10, 100, 600, 5500, 25000 };
        private static int blankScore = 5;
        private static Dictionary<String, int> attackScore4;
        private static Dictionary<String, int> attackScore3;
        private static Dictionary<String, int> attackScore2;
        private static Dictionary<String, int> attackScore1;

        // ki hieu N: opp or blank or border
        // O: ownSTT
        // X: oppSTT
        // -: blank
        // A: own or opp or blank)
        private void MakeAttackScore4()
        {
            attackScore4.Add("N-OOOO-N", attackScore[4]);

            attackScore4.Add("NXOOOO-N", (attackScore[4] + attackScore[3]) / 2);
            //attackScore4.Add("N-OOOOXN", (attackScore[4] + attackScore[3]) / 2);

            attackScore4.Add("N-OOOOXO", (attackScore[4] + attackScore[3]) / 2);
            //attackScore4.Add("OXOOOO-N", (attackScore[4] + attackScore[3]) / 2);

            attackScore4.Add("N-OOOO-O", (attackScore[4] + attackScore[3]) / 2);
            //attackScore4.Add("O-OOOO-N", (attackScore[4] + attackScore[3]) / 2);

            attackScore4.Add("N-OOOON", (attackScore[4] + attackScore[3]) / 2);
            //attackScore4.Add("NOOOO-N", (attackScore[4] + attackScore[3]) / 2);
        }

        private void MakeAttackScore3()
        {   
            attackScore3.Add("NXXOOO-ON", (attackScore[4] + attackScore[3]) / 2);
            attackScore3.Add("NOXOOO-ON", (attackScore[4] + attackScore[3]) / 2);
            attackScore3.Add("N-XOOO-ON", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("NO-OOOXXN", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("NO-OOOXON", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("NO-OOOX-N", (attackScore[4] + attackScore[3]) / 2);

            attackScore3.Add("NXXOOO--N", (attackScore[3] + attackScore[2]) / 2);
            attackScore3.Add("NOXOOO--N", (attackScore[3] + attackScore[2]) / 2);
            attackScore3.Add("N-XOOO--N", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("N--OOOXXN", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("N--OOOXON", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("N--OOOX-N", (attackScore[3] + attackScore[2]) / 2);

            attackScore3.Add("NO-OOO-ON", attackScore[4]);
            attackScore3.Add("NO-OOO-XN", (attackScore[4] + attackScore[3]) / 2);
            attackScore3.Add("NO-OOO--N", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("NX-OOO-ON", (attackScore[4] + attackScore[3]) / 2);
            attackScore3.Add("NX-OOO-XN", (attackScore[3] + attackScore[2]) / 2);
            attackScore3.Add("NX-OOO--N", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("N--OOO-ON", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("N--OOO-XN", attackScore[3]);
            attackScore3.Add("N--OOO--N", attackScore[3]);



            attackScore3.Add("NO-OOO-OO", (attackScore[4] + attackScore[3]) / 2);
            attackScore3.Add("NO-OOO-XO", (attackScore[4] + attackScore[3]) / 2);
            attackScore3.Add("NO-OOO--O", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("OO-OOO-ON", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("OX-OOO-ON", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("O--OOO-ON", (attackScore[4] + attackScore[3]) / 2);

            attackScore3.Add("NX-OOO-XO", (attackScore[3] + attackScore[2]) / 2);
            attackScore3.Add("NX-OOO--O", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("OX-OOO-XN", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("O--OOO-XN", (attackScore[3] + attackScore[2]) / 2);

            attackScore3.Add("N--OOO-OO", (attackScore[3] + attackScore[2]) / 2);
            attackScore3.Add("N--OOO-XO", attackScore[3]);
            attackScore3.Add("N--OOO--O", attackScore[3]);
            //attackScore3.Add("OO-OOO--N", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("OX-OOO--N", attackScore[3]);
            //attackScore3.Add("O--OOO--N", attackScore[3]);

            attackScore3.Add("NO-OOOXOO", (attackScore[4] + attackScore[3]) / 2);
            attackScore3.Add("NO-OOOXXO", (attackScore[4] + attackScore[3]) / 2);
            attackScore3.Add("NO-OOOX-O", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("OOXOOO-ON", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("OXXOOO-ON", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("O-XOOO-ON", (attackScore[4] + attackScore[3]) / 2);

            attackScore3.Add("N--OOOXOO", (attackScore[3] + attackScore[2]) / 2);
            attackScore3.Add("N--OOOXXO", (attackScore[3] + attackScore[2]) / 2);
            attackScore3.Add("N--OOOX-O", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("OOXOOO--N", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("OXXOOO--N", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("O-XOOO--N", (attackScore[3] + attackScore[2]) / 2);


   
            attackScore3.Add("N-OOO-XN", (attackScore[3] + attackScore[2]) / 2);
            attackScore3.Add("N-OOO-ON", (attackScore[4] + attackScore[3]) / 2);
            attackScore3.Add("N-OOO--N", attackScore[3]);
            attackScore3.Add("NXOOO-ON", (attackScore[4] + attackScore[3]) / 2);
            attackScore3.Add("NXOOO--N", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("NX-OOO-N", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("NO-OOO-N", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("N--OOO-N", attackScore[3]);
            //attackScore3.Add("NO-OOOXN", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("N--OOOXN", (attackScore[3] + attackScore[2]) / 2);

            attackScore3.Add("N-OOO-XO", (attackScore[3] + attackScore[2]) / 2);
            attackScore3.Add("N-OOO--O", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("OX-OOO-N", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("O--OOO-N", (attackScore[3] + attackScore[2]) / 2);

            attackScore3.Add("NOOO-ON", (attackScore[3] + attackScore[2]) / 2);
            attackScore3.Add("NOOO--N", (attackScore[3] + attackScore[2]) / 2);
            //attackScore3.Add("NO-OOON", (attackScore[4] + attackScore[3]) / 2);
            //attackScore3.Add("N--OOON", (attackScore[3] + attackScore[2]) / 2);
        }

        private void MakeAttackScore2()
        {
            attackScore2.Add("NAAXOO-OON", (attackScore[4] + attackScore[2]) / 2);
            attackScore2.Add("NAAXOO-O-N", (attackScore[3] + attackScore[2]) / 2 - blankScore);
            attackScore2.Add("NAAXOO--ON", (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore);
            attackScore2.Add("NAAXOO---N", (attackScore[2] + attackScore[1]) / 2);
            //attackScore2.Add("NOO-OOXAAN", (attackScore[4] + attackScore[2]) / 2);
            //attackScore2.Add("N-O-OOXAAN", (attackScore[3] + attackScore[2]) / 2 - blankScore);
            //attackScore2.Add("NO--OOXAAN", (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore);
            //attackScore2.Add("N---OOXAAN", (attackScore[2] + attackScore[1]) / 2);

            attackScore2.Add("NAX-OO-OON", (attackScore[4] + attackScore[2]) / 2);
            attackScore2.Add("NAX-OO-OXN", (attackScore[3] + attackScore[2]) / 2);
            attackScore2.Add("NAX-OO-O-N", attackScore[3]);
            attackScore2.Add("NAX-OO--ON", (attackScore[2] + attackScore[1]) / 2 - 2 * blankScore);
            attackScore2.Add("NAX-OO--XN", (attackScore[2] + attackScore[1]) / 2);
            attackScore2.Add("NAX-OO---N", attackScore[2]);
            //attackScore2.Add("NOO-OO-XAN", (attackScore[4] + attackScore[2]) / 2);
            //attackScore2.Add("NXO-OO-XAN", (attackScore[3] + attackScore[2]) / 2);
            //attackScore2.Add("N-O-OO-XAN", attackScore[3]);
            //attackScore2.Add("NO--OO-XAN", (attackScore[2] + attackScore[1]) / 2 - 2 * blankScore);
            //attackScore2.Add("NX--OO-XAN", (attackScore[2] + attackScore[1]) / 2);
            //attackScore2.Add("N---OO-XAN", attackScore[2]);



            attackScore2.Add("NXO-OO-OON", (attackScore[4] + attackScore[2]) / 2);
            //attackScore2.Add("NOO-OO-OXN", (attackScore[4] + attackScore[2]) / 2);
            attackScore2.Add("NXO-OO-O-N", (attackScore[3] + attackScore[2]) / 2 - blankScore);
            //attackScore2.Add("N-O-OO-OXN", (attackScore[3] + attackScore[2]) / 2 - blankScore);
            attackScore2.Add("NOO-OO-OON", attackScore[4]);
            attackScore2.Add("N-O-OO-OON", (attackScore[4] + attackScore[2]) / 2);
            //attackScore2.Add("NOO-OO-O-N", (attackScore[4] + attackScore[2]) / 2);
            attackScore2.Add("N-O-OO-O-N", (attackScore[3] + attackScore[2]) / 2);

            attackScore2.Add("NXO-OO--ON", attackScore[3]);
            //attackScore2.Add("NO--OO-OXN", attackScore[3]);
            attackScore2.Add("NXO-OO--XN", (attackScore[3] + attackScore[2]) / 2 - blankScore);
            //attackScore2.Add("NX--OO-OXN", (attackScore[3] + attackScore[2]) / 2 - blankScore);
            attackScore2.Add("NXO-OO---N", (attackScore[3] + attackScore[2]) / 2 - blankScore);
            //attackScore2.Add("N---OO-OXN", (attackScore[3] + attackScore[2]) / 2 - blankScore);

            attackScore2.Add("NOO-OO--ON", (attackScore[4] + attackScore[2]) / 2);
            //attackScore2.Add("NO--OO-OON", (attackScore[4] + attackScore[2]) / 2);
            attackScore2.Add("NOO-OO--XN", (attackScore[4] + attackScore[2]) / 2);
            //attackScore2.Add("NX--OO-OON", (attackScore[4] + attackScore[2]) / 2);
            attackScore2.Add("NOO-OO---N", (attackScore[4] + attackScore[2]) / 2);
            //attackScore2.Add("N---OO-OON", (attackScore[4] + attackScore[2]) / 2);

            attackScore2.Add("N-O-OO--ON", attackScore[3]);
            //attackScore2.Add("NO--OO-O-N", attackScore[3]);
            attackScore2.Add("N-O-OO--XN", attackScore[3]);
            //attackScore2.Add("NX--OO-O-N", attackScore[3]);
            attackScore2.Add("N-O-OO---N", attackScore[3]);
            //attackScore2.Add("N---OO-O-N", attackScore[3]);


            attackScore2.Add("NX--OO--ON", (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore);
            //attackScore2.Add("NO--OO--XN", (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore);
            attackScore2.Add("NX--OO--XN", attackScore[2]);
            attackScore2.Add("NX--OO---N", attackScore[2]);
            //attackScore2.Add("N---OO--XN", attackScore[2]);
            attackScore2.Add("NO--OO--ON", (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore);
            attackScore2.Add("NO--OO---N", (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore);
            //attackScore2.Add("N---OO--ON", (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore);
            attackScore2.Add("N---OO---N", attackScore[2]);



        }

        private void MakeAttackScore1()
        {

        }

        private int genRowAttack(Node node, Position move)
        {
            
            int oppHeadCol = -1, oppTailCol = node.SizeBoard;
            int ownHeadCol = move.Col, ownTailCol = move.Col;
            int ownContinuous = 1;
            int row = move.Row;
            bool flag = true;
            for (int i = 1; i < 5 && move.Col + i < node.SizeBoard; i++)
            {
                if (flag && node.Matrix[row, move.Col + i].STT == ownSTT)
                {
                    ownContinuous++;
                    ownTailCol = move.Col + i;
                }
                else if (node.Matrix[row, move.Col + i].STT == oppSTT)
                {
                    oppTailCol = move.Col + i;
                    break;
                }
                else // oppState
                {
                    flag = false;
                }
            }
            for (int i = 1; i < 5 && move.Col - i >= 0; i++)
            {
                if (flag && node.Matrix[row, move.Col - i].STT == ownSTT)
                {
                    ownContinuous++;
                    ownHeadCol = move.Col - i;
                }
                else if (node.Matrix[row, move.Col - i].STT == oppSTT)
                {
                    oppHeadCol = move.Col - i;
                    break;
                }
                else // oppState
                {
                    flag = false;
                }
            }

            if (oppTailCol - oppHeadCol > 5)
            {
                if (ownContinuous == 5)
                {
                    return attackScore[5];
                }
                else if (ownContinuous == 4)
                {
                    if (ownHeadCol - 1 >= 0 && ownTailCol + 1 < node.SizeBoard)
                    {
                        bool flag1, flag2;
                        if (ownHeadCol - 2 < 0) flag1 = true;
                        else flag1 = (node.Matrix[row, ownHeadCol - 2].STT != ownSTT);
                        if (ownTailCol + 2 >= node.SizeBoard) flag2 = true;
                        else flag2 = (node.Matrix[row, ownTailCol + 2].STT != ownSTT);
                        if (flag1 && flag2)
                        {
                            if (ownTailCol + 1 == oppTailCol || ownHeadCol - 1 == oppHeadCol)
                                return (attackScore[4] + attackScore[3]) / 2;
                            return attackScore[4];
                        }
                        else if (flag1)
                        {
                            if (ownHeadCol - 1 != oppHeadCol)
                                return (attackScore[4] + attackScore[3]) / 2;
                        }
                        else if (flag2)
                        {
                            if (ownTailCol + 1 != oppTailCol)
                                return (attackScore[4] + attackScore[3]) / 2;
                        }

                    }
                    else if (ownHeadCol - 1 < 0)
                    {
                        if (node.Matrix[row, ownTailCol + 2].STT != ownSTT)
                            return (attackScore[4] + attackScore[3]) / 2;
                    }
                    else if (ownTailCol + 1 >= node.SizeBoard)
                    {
                        if (node.Matrix[row, ownHeadCol - 2].STT != ownSTT)
                            return (attackScore[4] + attackScore[3]) / 2;
                    }
                }
                else if (ownContinuous == 3)
                {
                    if (ownHeadCol - 2 >= 0 && ownTailCol + 2 < node.SizeBoard)
                    {
                        bool flag1, flag2;
                        if (ownHeadCol - 3 < 0) flag1 = true;
                        else flag1 = (node.Matrix[row, ownHeadCol - 3].STT != ownSTT);
                        if (ownTailCol + 3 >= node.SizeBoard) flag2 = true;
                        else flag2 = (node.Matrix[row, ownTailCol + 3].STT != ownSTT);
                        if (flag1 && flag2)
                        {
                            if (ownHeadCol - 1 == oppHeadCol)
                            {
                                if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                {
                                    return (attackScore[4] + attackScore[3]) / 2;
                                }
                                else
                                {
                                    return (attackScore[3] + attackScore[2]) / 2;
                                }
                            }
                            else if (ownTailCol + 1 == oppTailCol)
                            {
                                if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                {
                                    return (attackScore[4] + attackScore[3]) / 2;
                                }
                                else
                                {
                                    return (attackScore[3] + attackScore[2]) / 2;
                                }
                            }
                            else
                            {
                                if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                    {
                                        return attackScore[4];
                                    }
                                    else
                                    {
                                        return (attackScore[4] + attackScore[3]) / 2;
                                    }
                                }
                                else if (ownHeadCol - 2 == oppHeadCol)
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                    {
                                        return (attackScore[4] + attackScore[3]) / 2;
                                    }
                                    else
                                    {
                                        return (attackScore[3] + attackScore[2]) / 2;
                                    }
                                }
                                else
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                    {
                                        return (attackScore[4] + attackScore[3]) / 2;
                                    }
                                    else
                                    {
                                        return attackScore[3];
                                    }
                                }
                            }
                        }
                        else if (flag1)
                        {
                            if (ownHeadCol - 1 != oppHeadCol && ownTailCol + 1 != oppTailCol)
                            {
                                if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                {
                                    return (attackScore[4] + attackScore[3]) / 2;
                                }
                                else if (ownHeadCol - 2 == oppHeadCol)
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT != ownSTT)
                                    {
                                        return (attackScore[3] + attackScore[2]) / 2;
                                    }
                                }
                                else
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT != ownSTT)
                                    {
                                        return attackScore[3];
                                    }
                                }
                            }
                            else if (ownTailCol + 1 == oppTailCol)
                            {
                                if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                {
                                    return (attackScore[4] + attackScore[3]) / 2;
                                }
                                else
                                {//blank
                                    return (attackScore[3] + attackScore[2]) / 2;
                                }
                            }
                        }
                        else if (flag2)
                        {
                            if (ownHeadCol - 1 != oppHeadCol && ownTailCol + 1 != oppTailCol)
                            {
                                if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                {
                                    return (attackScore[4] + attackScore[3]) / 2;
                                }
                                else if (ownTailCol + 2 == oppTailCol)
                                {
                                    if (node.Matrix[row, ownHeadCol - 2].STT != ownSTT)
                                    {
                                        return (attackScore[3] + attackScore[2]) / 2;
                                    }
                                }
                                else
                                {
                                    if (ownHeadCol - 2 == oppHeadCol)
                                    {
                                        return (attackScore[3] + attackScore[2]) / 2;
                                    }
                                    if (node.Matrix[row, ownHeadCol - 2].STT == Box.State.blank)
                                    {
                                        return attackScore[3];
                                    }
                                }
                            }
                            else if (ownHeadCol - 1 == oppHeadCol)
                            {
                                if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                {
                                    return (attackScore[4] + attackScore[3]) / 2;
                                }
                                else
                                {
                                    return (attackScore[3] + attackScore[2]) / 2;
                                }
                            }
                        }
                        else
                        {
                            if (ownHeadCol - 1 != oppHeadCol && ownTailCol + 1 != oppTailCol)
                            {
                                if (node.Matrix[row, ownHeadCol - 2].STT == Box.State.blank)
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT == Box.State.blank)
                                    {
                                        return attackScore[3];
                                    }
                                    if (ownTailCol + 2 == oppTailCol)
                                    {
                                        return (attackScore[3] + attackScore[2]) / 2;
                                    }
                                }
                                else if (ownHeadCol - 2 == oppHeadCol)
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT != ownSTT)
                                    {
                                        return (attackScore[3] + attackScore[2]) / 2;
                                    }
                                }
                            }
                        }
                    }
                    else if (ownHeadCol - 2 < 0)
                    {
                        if (ownHeadCol - 1 >= 0)
                        {
                            if (node.Matrix[row, ownTailCol + 3].STT != ownSTT)
                            {
                                if (node.Matrix[row, ownHeadCol - 1].STT == Box.State.blank)
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT == oppSTT)
                                    {
                                        return (attackScore[3] + attackScore[2]) / 2;
                                    }
                                    else if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                    {
                                        return (attackScore[4] + attackScore[3]) / 2;
                                    }
                                    else
                                    {
                                        return (attackScore[3]);
                                    }
                                }
                                if (ownHeadCol - 1 == oppHeadCol)
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                    {
                                        return (attackScore[4] + attackScore[3]) / 2;
                                    }
                                    else
                                    {
                                        return (attackScore[3] + attackScore[2]) / 2;
                                    }
                                }
                            }
                            else
                            {
                                if (node.Matrix[row, ownHeadCol - 1].STT == Box.State.blank)
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT != ownSTT)
                                    {
                                        return (attackScore[3] + attackScore[2]) / 2;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (node.Matrix[row, ownTailCol + 3].STT != ownSTT)
                            {
                                if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                {
                                    return (attackScore[4] + attackScore[3]) / 2;
                                }
                                else
                                {
                                    return (attackScore[3] + attackScore[2]) / 2;
                                }
                            }
                        }
                    }
                    else if (ownTailCol + 2 >= node.SizeBoard)
                    {
                        if (ownTailCol + 1 < node.SizeBoard)
                        {
                            if (node.Matrix[row, ownHeadCol - 3].STT != ownSTT)
                            {
                                if (node.Matrix[row, ownTailCol + 1].STT == Box.State.blank)
                                {
                                    if (node.Matrix[row, ownHeadCol - 2].STT == oppSTT)
                                    {
                                        return (attackScore[3] + attackScore[2]) / 2;
                                    }
                                    else if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                    {
                                        return (attackScore[4] + attackScore[3]) / 2;
                                    }
                                    else
                                    {
                                        return (attackScore[3]);
                                    }
                                }
                                if (ownTailCol + 1 == oppTailCol)
                                {
                                    if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                    {
                                        return (attackScore[4] + attackScore[3]) / 2;
                                    }
                                    else
                                    {
                                        return (attackScore[3] + attackScore[2]) / 2;
                                    }
                                }
                            }
                            else
                            {
                                if (node.Matrix[row, ownTailCol + 1].STT == Box.State.blank)
                                {
                                    if (node.Matrix[row, ownHeadCol - 2].STT != ownSTT)
                                    {
                                        return (attackScore[3] + attackScore[2]) / 2;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (node.Matrix[row, ownHeadCol - 3].STT != ownSTT)
                            {
                                if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                {
                                    return (attackScore[4] + attackScore[3]) / 2;
                                }
                                else
                                {
                                    return (attackScore[3] + attackScore[2]) / 2;
                                }
                            }
                        }
                    }
                }
                else if (ownContinuous == 2)
                {
                    if (ownHeadCol - 3 >= 0 && ownTailCol + 3 < node.SizeBoard)
                    {
                        bool flag1, flag2;
                        if (ownHeadCol - 4 < 0) flag1 = true;
                        else flag1 = (node.Matrix[row, ownHeadCol - 4].STT != ownSTT);
                        if (ownTailCol + 4 >= node.SizeBoard) flag2 = true;
                        else flag2 = (node.Matrix[row, ownTailCol + 4].STT != ownSTT);
                        if (flag1 && flag2)
                        {
                            if (ownHeadCol - 1 == oppHeadCol)
                            {
                                if(node.Matrix[row, ownTailCol + 2].STT == ownSTT
                                    && node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                {
                                    return (attackScore[4] + attackScore[2]) / 2;
                                }
                                if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                {
                                    return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                }
                                else if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                {
                                    return (attackScore[3] + attackScore[2]) / 2 - blankScore * 2;
                                }
                                return (attackScore[2] + attackScore[1]) / 2;
                            }
                            else if (ownTailCol + 1 == oppTailCol)
                            {
                                if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT
                                    && node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                {
                                    return (attackScore[4] + attackScore[2]) / 2;
                                }
                                else if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                {
                                    return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                }
                                else if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                {
                                    return (attackScore[3] + attackScore[2]) / 2 - blankScore * 2;
                                }
                                return (attackScore[2] + attackScore[1]) / 2;
                            }
                            else
                            {
                                if (ownHeadCol - 2 == oppHeadCol)
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                    {
                                        if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                        {
                                            return (attackScore[4] + attackScore[2]) / 2;
                                        }
                                        else if (ownTailCol + 3 == oppTailCol)
                                        {
                                            return (attackScore[3] + attackScore[2]) / 2;
                                        }
                                        else
                                        {
                                            return attackScore[3];
                                        }
                                    }
                                    else
                                    {   // is blank box
                                        if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                        {
                                            return (attackScore[3] + attackScore[2]) / 2 - blankScore * 2;
                                        }
                                        else if (ownTailCol + 3 == oppTailCol)
                                        {
                                            return (attackScore[2] + attackScore[1]) / 2;
                                        }
                                        else
                                        {
                                            return (attackScore[2]);
                                        }
                                    }
                                }
                                if (ownTailCol + 2 == oppTailCol)
                                {
                                    if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                    {
                                        if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                        {
                                            return (attackScore[4] + attackScore[2]) / 2;
                                        }
                                        else if (ownHeadCol - 3 == oppHeadCol)
                                        {
                                            return (attackScore[3] + attackScore[2]) / 2;
                                        }
                                        else
                                        {
                                            return attackScore[3];
                                        }
                                    }
                                    else
                                    {   // is blank box
                                        if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                        {
                                            return (attackScore[3] + attackScore[2]) / 2 - blankScore * 2;
                                        }
                                        else if (oppHeadCol - 3 == oppHeadCol)
                                        {
                                            return (attackScore[2] + attackScore[1]) / 2;
                                        }
                                        else
                                        {
                                            return (attackScore[2]);
                                        }
                                    }
                                }
                                //ownHeadCol - 2 != oppHeadCol && ownTailCol + 2 != oppTailCol
                                if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                    {
                                        if (ownHeadCol - 3 == oppHeadCol)
                                        {
                                            if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                            {
                                                return (attackScore[4] + attackScore[2]) / 2;
                                            }
                                            if (ownTailCol + 3 != oppTailCol)
                                            {
                                                return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                            }
                                        }
                                        else if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                        {
                                            if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                            {
                                                return attackScore[4];
                                            }
                                            else
                                            {// blank box or opp
                                                return (attackScore[4] + attackScore[2]) / 2;
                                            }
                                        }
                                        else
                                        {// blank box
                                            if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                            {
                                                return (attackScore[4] + attackScore[3]) / 2;
                                            }
                                            else if (ownTailCol + 3 == oppTailCol)
                                            {
                                                return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                            }
                                            else
                                            {// blank box
                                                return (attackScore[3] + attackScore[2]) / 2;
                                            }
                                        }
                                    }
                                    else
                                    {// blank box
                                        if (ownHeadCol - 3 == oppHeadCol)
                                        {
                                            if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                            {
                                                return attackScore[3];
                                            }
                                            else
                                            {// blank or opp
                                                return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                            }
                                        }
                                        else if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                        {
                                            return (attackScore[4] + attackScore[2]) / 2;
                                        }
                                        else
                                        {// blank box
                                            return attackScore[3];
                                        }
                                    }
                                }
                                else
                                {// blank
                                    if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                    {
                                        if (ownHeadCol - 3 == oppHeadCol)
                                        {
                                            if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                            {
                                                return (attackScore[4] + attackScore[2]) / 2;
                                            }
                                            else if (ownTailCol + 3 == oppTailCol)
                                            {// blank or opp
                                                return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                            }
                                            else
                                            {
                                                return attackScore[3];
                                            }
                                        }
                                        else if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                        {
                                            if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                            {
                                                return (attackScore[4] + attackScore[2]) / 2;
                                            }
                                            else if (ownTailCol + 3 == oppTailCol)
                                            {
                                                return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                            }
                                            else
                                            {// blank or opp
                                                return attackScore[3];
                                            }
                                        }
                                        else
                                        {// blank box
                                            if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                            {
                                                return (attackScore[4] + attackScore[2]) / 2;
                                            }
                                            else if (ownTailCol + 3 == oppTailCol)
                                            {
                                                return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                            }
                                            else
                                            {// blank box
                                                return attackScore[3];
                                            }
                                        }
                                    }
                                    else
                                    {// blank
                                        if (ownHeadCol - 3 == oppHeadCol)
                                        {// opp
                                            if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                            {
                                                return (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore;
                                            }
                                            else
                                            {
                                                return attackScore[2];
                                            }
                                        }
                                        else if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                        {
                                            return (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore;
                                        }
                                        else
                                        {// blank
                                            if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                            {
                                                return (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore;
                                            }
                                            else
                                            {// blank or opp
                                                return attackScore[2];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (flag1)
                        {
                            if (ownTailCol + 1 == oppTailCol)
                            {
                                if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT
                                    && node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                {
                                    return (attackScore[4] + attackScore[2]) / 2;
                                }
                                if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                {
                                    return (attackScore[3] + attackScore[2]) - blankScore;
                                }
                                if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                {
                                    return (attackScore[3] + attackScore[2]) - 2 * blankScore;
                                }
                                return (attackScore[2] + attackScore[1]) / 2;
                            }
                            if (ownHeadCol - 1 != oppHeadCol && ownTailCol + 1 != oppTailCol)
                            {
                                if (ownHeadCol - 2 == oppHeadCol)
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                    {
                                        if (node.Matrix[row, ownTailCol + 3].STT != ownSTT)
                                        {
                                            return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                        }
                                    }
                                    else
                                    {//blank
                                        if (node.Matrix[row, ownTailCol + 3].STT != ownSTT)
                                        {
                                            return (attackScore[2] + attackScore[1]) / 2;
                                        }
                                    }
                                }
                                if (ownTailCol + 2 == oppTailCol)
                                {
                                    if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                    {
                                        if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                        {
                                            return (attackScore[4] + attackScore[2]) / 2;
                                        }
                                        else if (ownHeadCol - 3 == oppHeadCol)
                                        {
                                            return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                        }
                                        else
                                        {
                                            return attackScore[3];
                                        }
                                    }
                                    else
                                    {//blank
                                        if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                        {
                                            return (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore;
                                        }
                                        else if (ownHeadCol - 3 == oppHeadCol)
                                        {
                                            return (attackScore[2] + attackScore[1]) / 2;
                                        }
                                        else
                                        {
                                            return attackScore[2];
                                        }
                                    }
                                }
                                //ownHeadCol - 2 !- oppHeadCol && ownTailCol + 2 != oppHeadCol
                                if (node.Matrix[row, ownHeadCol - 2].STT == ownSTT)
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                    {
                                        if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                        {
                                            return (attackScore[4] + attackScore[2]) / 2;
                                        }
                                        else if (ownHeadCol - 3 == oppHeadCol)
                                        {
                                            return 0;
                                        }
                                        else
                                        {//blank
                                            return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                        }
                                    }
                                    else
                                    {//blank
                                        if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                        {
                                            return (attackScore[4] + attackScore[2]) / 2;
                                        }
                                        else if (ownHeadCol - 3 == oppHeadCol)
                                        {
                                            return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                        }
                                        else
                                        {//blank
                                            return attackScore[3];
                                        }
                                    }
                                }
                                else// node.Matrix[row, ownHeadCol - 2].STT == Box.State.blank
                                {
                                    if (node.Matrix[row, ownTailCol + 2].STT == ownSTT)
                                    {
                                        if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                        {
                                            return (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore;
                                        }
                                        else if (ownHeadCol - 3 == oppHeadCol)
                                        {
                                            if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                            {
                                                return 0;
                                            }
                                            // blank or opp
                                            return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                        }
                                        else
                                        {//blank
                                            if (node.Matrix[row, ownTailCol + 3].STT == ownSTT)
                                            {
                                                return (attackScore[2] + attackScore[1]) / 2;
                                            }
                                            // blank or opp
                                            return (attackScore[3] + attackScore[2]) / 2 - blankScore;
                                        }
                                    }
                                    else
                                    {// blank
                                        if (node.Matrix[row, ownHeadCol - 3].STT == ownSTT)
                                        {
                                            return (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore;
                                        }
                                        else if (ownHeadCol - 3 == oppHeadCol)
                                        {
                                            if (node.Matrix[row, ownTailCol + 3].STT == Box.State.blank)
                                            {
                                                return attackScore[2];
                                            }
                                            // own or opp
                                            return (attackScore[2] + attackScore[1]) / 2;
                                        }
                                        else
                                        {//blank
                                            return (attackScore[3] + attackScore[2]) / 2 - 2 * blankScore;
                                        }
                                    }
                                }
                            }
                        }
                        else if (flag2)
                        {

                        }
                        else
                        {

                        }
                    }
                    else if (ownHeadCol - 3 < 0)
                    {

                    }
                    else if (ownTailCol + 3 >= node.SizeBoard)
                    {

                    }
                }
                else if (ownContinuous == 1)
                {

                }
            }
            return 0;
        }
        private int genColAttack(Node node, Position move)
        {
            return 0;
        }
        private int genLeftDiagAttack(Node node, Position move)
        {
            return 0;
        }
        private int genRightDiagAttack(Node node, Position move)
        {
            return 0;
        }
        private int getRowAttackScore(Node node, Position move)
        {
            Box.State ownSTT = node.Matrix[move.Row, move.Col].STT;
            Box.State oppSTT = (Box.State)(((int)ownSTT) ^ 1);
            return 0;
        }
        #endregion

        private static long[] AtkArr = new long[7] { 0, 9, 54, 162, 1458, 13112, 118008};
        private static long[] DefArr = new long[7] { 0, 3, 27, 99, 729, 6561, 59049};

        #region Heuristic
        public static long Eluavation(Node node, Position move)
        {
            ownSTT = node.Matrix[move.Row, move.Col].STT;
            oppSTT = (Box.State)(((int)ownSTT) ^ 1);

            //Tính điểm tấn công và phòng ngự
            long atkC = AtkPts_InCol(node, move.Row, move.Col);
            long atkR = AtkPts_InRow(node, move.Row, move.Col);
            long atkLD = AtkPts_InLeftDiagonal(node, move.Row, move.Col);
            long atkRD = AtkPts_InRightDiagonal(node, move.Row, move.Col);
            long AtkPts = atkC + atkR + atkLD + atkRD;
            long defC = DefPts_InCol(node, move.Row, move.Col);
            long defR = DefPts_InRow(node, move.Row, move.Col);
            long defRD = DefPts_InRightDiagonal(node, move.Row, move.Col);
            long defLD = DefPts_InLeftDiagonal(node, move.Row, move.Col);
            long DefPts = defC + defR + defRD + defLD;
            //Lấy điểm lớn nhất
            long temp = Math.Max(AtkPts, DefPts);
            //long temp = Math.Abs(AtkPts - DefPts);
            return temp;
        }
        //Duyệt tấn công
        private static long AtkPts_InCol(Node node, int currRow, int currCol)
        {
            long SumPts = 0;
            int owns = 0;
            int opps = 0;

            for (int i = 1; i < 6 && currRow + i < node.SizeBoard; i++)
            {
                if (node.Matrix[currRow + i, currCol].STT == ownSTT)
                {//Nếu gặp quân ta thì cộng số lượng vào
                    owns++;
                }
                else if (node.Matrix[currRow + i, currCol].STT == oppSTT)
                {//Gặp quân địch thì cộng số lượng, trừ điểm và break
                    SumPts -= 9;
                    opps++;
                    break;
                }
                else
                    break;
            }
            for (int i = 1; i < 6 && currRow - i >= 0; i++)
            {
                if (node.Matrix[currRow - i, currCol].STT == ownSTT)
                {
                    owns++;
                }
                else if (node.Matrix[currRow - i, currCol].STT == oppSTT)
                {
                    SumPts -= 9;
                    opps++;
                    break;
                }
                else
                    break;
            }

            //Nếu bị chặn 2 đầu thì điểm tấn công = 0
            if (opps == 2)
            {
                return 0;
            }

            //Tính điểm tổng
            SumPts -= AtkArr[opps];
            SumPts += (owns <= 6 ? AtkArr[owns] : 0);

            return SumPts;
        }
        private static long AtkPts_InRow(Node node, int currRow, int currCol)
        {
            long SumPts = 0;
            int owns = 0;
            int opps = 0;

            for (int i = 1; i < 6 && currCol + i < node.SizeBoard; i++)
            {
                if (node.Matrix[currRow, currCol + i].STT == ownSTT)
                {
                    owns++;
                }
                else if (node.Matrix[currRow, currCol + i].STT == oppSTT)
                {
                    SumPts -= 9;
                    opps++;
                    break;
                }
                else
                    break;
            }
            for (int i = 1; i < 6 && currCol - i >= 0; i++)
            {
                if (node.Matrix[currRow, currCol - i].STT == ownSTT)
                {
                    owns++;
                }
                else if (node.Matrix[currRow, currCol - i].STT == oppSTT)
                {
                    SumPts -= 9;
                    opps++;
                    break;
                }
                else
                    break;
            }

            if (opps == 2)
            {
                return 0;
            }
            SumPts -= AtkArr[opps];
            SumPts += (owns <= 6 ? AtkArr[owns] : 0);

            return SumPts;
        }
        private static long AtkPts_InRightDiagonal(Node node, int currRow, int currCol)
        {
            long SumPts = 0;
            int owns = 0;
            int opps = 0;

            for (int i = 1; i < 6 && currCol + i < node.SizeBoard && currRow - i >= 0; i++)
            {
                if (node.Matrix[currRow - i, currCol + i].STT == ownSTT)
                {
                    owns++;
                }
                else if (node.Matrix[currRow - i, currCol + i].STT == oppSTT)
                {
                    SumPts -= 9;
                    opps++;
                    break;
                }
                else
                    break;
            }
            for (int i = 1; i < 6 && currRow + i < node.SizeBoard && currCol - i >= 0; i++)
            {
                if (node.Matrix[currRow + i, currCol - i].STT == ownSTT)
                {
                    owns++;
                }
                else if (node.Matrix[currRow + i, currCol - i].STT == oppSTT)
                {
                    SumPts -= 9;
                    opps++;
                    break;
                }
                else
                    break;
            }

            if (opps == 2)
            {
                return 0;
            }
            SumPts -= AtkArr[opps];
            SumPts += (owns <= 6 ? AtkArr[owns] : 0);

            return SumPts;
        }
        private static long AtkPts_InLeftDiagonal(Node node, int currRow, int currCol)
        {
            long SumPts = 0;
            int owns = 0;
            int opps = 0;

            for (int i = 1; i < 6 && currCol - i >= 0 && currRow - i >= 0; i++)
            {
                if (node.Matrix[currRow - i, currCol - i].STT == ownSTT)
                {
                    owns++;
                }
                else if (node.Matrix[currRow - i, currCol - i].STT == oppSTT)
                {
                    SumPts -= 9;
                    opps++;
                    break;
                }
                else
                    break;
            }
            for (int i = 1; i < 6 && currRow + i < node.SizeBoard && currCol + i < node.SizeBoard; i++)
            {
                if (node.Matrix[currRow + i, currCol + i].STT == ownSTT)
                {
                    owns++;
                }
                else if (node.Matrix[currRow + i, currCol + i].STT == oppSTT)
                {
                    SumPts -= 9;
                    opps++;
                    break;
                }
                else
                    break;
            }

            if (opps == 2)
            {
                return 0;
            }

            SumPts -= AtkArr[opps];
            SumPts += (owns <= 6 ? AtkArr[owns] : 0);

            return SumPts;
        }

        //Duyệt phòng thủ
        private static long DefPts_InCol(Node node, int currRow, int currCol)
        {
            long SumPts = 0;
            int owns = 0;
            int opps = 0;

            for (int i = 1; i < 6 && currRow + i < node.SizeBoard; i++)
            {
                if (node.Matrix[currRow + i, currCol].STT == ownSTT)
                {
                    owns++;
                    break;
                }
                else if (node.Matrix[currRow + i, currCol].STT == oppSTT)
                {
                    opps++;
                }
                else
                    break;
            }
            for (int i = 1; i < 6 && currRow - i >= 0; i++)
            {
                if (node.Matrix[currRow - i, currCol].STT == ownSTT)
                {
                    owns++;
                    break;
                }
                else if (node.Matrix[currRow - i, currCol].STT == oppSTT)
                {
                    opps++;
                }
                else
                    break;
            }

            if (owns == 2)
            {
                return 0;
            }

            //Tính điểm phòng thủ
            SumPts += (opps <= 6 ? DefArr[opps] : 0);
            if (opps > 0)
                SumPts -= AtkArr[owns] * 2;

            return SumPts;
        }
        private static long DefPts_InRow(Node node, int currRow, int currCol)
        {
            long SumPts = 0;
            int owns = 0;
            int opps = 0;

            for (int i = 1; i < 6 && currCol + i < node.SizeBoard; i++)
            {
                if (node.Matrix[currRow, currCol + i].STT == ownSTT)
                {
                    owns++;
                    break;
                }
                else if (node.Matrix[currRow, currCol + i].STT == oppSTT)
                {
                    opps++;
                }
                else
                    break;
            }
            for (int i = 1; i < 6 && currCol - i >= 0; i++)
            {
                if (node.Matrix[currRow, currCol - i].STT == ownSTT)
                {
                    owns++;
                    break;
                }
                else if (node.Matrix[currRow, currCol - i].STT == oppSTT)
                {
                    opps++;
                }
                else
                    break;
            }

            if (owns == 2)
            {
                return 0;
            }


            SumPts += (opps <= 6 ? DefArr[opps] : 0);
            if (opps > 0)
                SumPts -= AtkArr[owns] * 2;

            return SumPts;
        }
        private static long DefPts_InRightDiagonal(Node node, int currRow, int currCol)
        {
            long SumPts = 0;
            int owns = 0;
            int opps = 0;

            for (int i = 1; i < 6 && currCol + i < node.SizeBoard && currRow - i >= 0; i++)
            {
                if (node.Matrix[currRow - i, currCol + i].STT == ownSTT)
                {
                    owns++;
                    break;
                }
                else if (node.Matrix[currRow - i, currCol + i].STT == oppSTT)
                {
                    opps++;
                }
                else
                    break;
            }
            for (int i = 1; i < 6 && currRow + i < node.SizeBoard && currCol - i >= 0; i++)
            {
                if (node.Matrix[currRow + i, currCol - i].STT == ownSTT)
                {
                    owns++;
                    break;
                }
                else if (node.Matrix[currRow + i, currCol - i].STT == oppSTT)
                {
                    opps++;
                }
                else
                    break;
            }

            if (owns == 2)
            {
                return 0;
            }


            SumPts += (opps <= 6 ? DefArr[opps] : 0);
            if (opps > 0)
                SumPts -= AtkArr[owns] * 2;

            return SumPts;
        }
        private static long DefPts_InLeftDiagonal(Node node, int currRow, int currCol)
        {
            long SumPts = 0;
            int owns = 0;
            int opps = 0;

            for (int i = 1; i < 6 && currCol - i >= 0 && currRow - i >= 0; i++)
            {
                if (node.Matrix[currRow - i, currCol - i].STT == ownSTT)
                {
                    owns++;
                    break;
                }
                else if (node.Matrix[currRow - i, currCol - i].STT == oppSTT)
                {
                    opps++;
                }
                else
                    break;
            }
            for (int i = 1; i < 6 && currRow + i < node.SizeBoard && currCol + i < node.SizeBoard; i++)
            {
                if (node.Matrix[currRow + i, currCol + i].STT == ownSTT)
                {
                    owns++;
                    break;
                }
                else if (node.Matrix[currRow + i, currCol + i].STT == oppSTT)
                {
                    opps++;
                }
                else
                    break;
            }

            if (owns == 2)
            {
                return 0;
            }

            SumPts += (opps <= 6 ? DefArr[opps] : 0);
            if (opps > 0)
                SumPts -= AtkArr[owns] * 2;

            return SumPts;
        }
        #endregion 
    }
}
