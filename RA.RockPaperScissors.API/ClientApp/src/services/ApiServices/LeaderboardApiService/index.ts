import { getLeaderboardUrl, getStartGameUrl } from "../../../constants";
import { LeaderboardDto } from "../../../models";
import ApiService from "../ApiService";

export default class LeaderboardApiService extends ApiService<LeaderboardDto> {
  /* Public methods */
  public async getStart(): Promise<LeaderboardDto> {
    const response = await this.get(getStartGameUrl());

    return response;
  }

  public async getLeaderboard(): Promise<LeaderboardDto> {
    const response = await this.get(getLeaderboardUrl());

    return response ;
  }
}
