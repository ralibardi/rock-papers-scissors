import { RockPaperScissors } from "../enums";

type PlayerDto = {
    id: number;
    score: number;
    lastMove: RockPaperScissors;
    isHuman: boolean;
};

export default PlayerDto;