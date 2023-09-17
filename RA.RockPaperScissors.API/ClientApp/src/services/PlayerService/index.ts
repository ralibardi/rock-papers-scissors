import { PlayerDto } from "../../models";
import { PlayerApiService } from "../ApiServices";

const apiService = new PlayerApiService();

export async function getPlayerMatch(player1: PlayerDto, player2: PlayerDto): Promise<PlayerDto> {
  const data: PlayerDto[] = [ player1, player2 ];
  const response = await apiService.getMatch(data);
  return response;
}

export async function patchPlayer(data: PlayerDto): Promise<PlayerDto> {
  const response = await apiService.patchPlayer(data);
  return response;
}