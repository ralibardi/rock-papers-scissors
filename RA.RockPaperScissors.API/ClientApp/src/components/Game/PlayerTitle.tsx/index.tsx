import React, { FunctionComponent, useState } from "react";
import Switch from "react-switch";
import { PlayerDto } from "../../../models";

interface IPlayerTitleProps {
  player: PlayerDto;
  handleChange: (player: PlayerDto, checked: boolean) => void;
  isChangeEnabled?: boolean;
}

const PlayerTitle: FunctionComponent<IPlayerTitleProps> = ({
  player,
  handleChange,
  isChangeEnabled = false,
}) => {
  const [checked, setChecked] = useState<boolean>(player.isHuman ?? false);

  function onChange(checked: boolean) {
    setChecked(checked);
    handleChange(player, checked);
  }

  return (
    <div>
      <h3>{checked ? "Player" : "Computer"}</h3>
      <Switch
        onChange={onChange}
        checked={checked}
        disabled={!isChangeEnabled}
      />
    </div>
  );
};

export default PlayerTitle;
