import { LeaderboardDto } from "../../models";
import { LeaderboardApiService } from "../ApiServices";

const apiService = new LeaderboardApiService();

export async function getPlayersBeforeGameStarts(): Promise<LeaderboardDto> {
  const response = await apiService.getStart();
  return response;
}

export async function getLeaderboard(): Promise<LeaderboardDto> {
  const response = await apiService.getLeaderboard();
  return response;
}
