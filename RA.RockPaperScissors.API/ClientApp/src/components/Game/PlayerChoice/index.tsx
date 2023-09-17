import React, { FunctionComponent, useState } from "react";
import { RockPaperScissors } from "../../../enums";

import "./PlayerChoice.scss";

interface IPlayerChoiceProps {
  isPlayerHuman: boolean;
  isChoiceEnabled: boolean;
  onClick: (move: RockPaperScissors) => void;
}

const PlayerChoice: FunctionComponent<IPlayerChoiceProps> = ({
  isPlayerHuman,
  isChoiceEnabled,
  onClick,
}) => {
  const [playerChoice, setPlayerChoice] = useState<RockPaperScissors>(
    RockPaperScissors.None
  );

  const handleClick = (move: RockPaperScissors) => {
    setPlayerChoice(move);
    onClick(move);
  };

  return (
    <div className="player-choice__container">
      {isPlayerHuman && (
        <div className="player-choice__button__container">
          <button
            type="button"
            className="player-choice__button"
            disabled={!isChoiceEnabled}
            onClick={handleClick.bind(null, RockPaperScissors.Rock)}
          >
            Rock
          </button>
          <button
            type="button"
            className="player-choice__button"
            disabled={!isChoiceEnabled}
            onClick={handleClick.bind(null, RockPaperScissors.Paper)}
          >
            Paper
          </button>
          <button
            type="button"
            className="player-choice__button"
            disabled={!isChoiceEnabled}
            onClick={handleClick.bind(null, RockPaperScissors.Scissors)}
          >
            Scissors
          </button>
        </div>
      )}
      <p>{`Selected: ${playerChoice}`}</p>
    </div>
  );
};

export default PlayerChoice;
