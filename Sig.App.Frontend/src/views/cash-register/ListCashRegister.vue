<i18n>
  {
    "en": {
      "title": "Cash registers",
      "add-cash-register": "Add",
      "available-cash-register": "{count} cash register(s)"
    },
    "fr": {
      "title": "Caisses",
      "add-cash-register": "Ajouter",
      "available-cash-register": "{count} caisse(s)"
    }
  }
</i18n>

<template>
  <Loading is-full-height>
    <RouterView v-slot="{ Component }">
      <AppShell :loading="marketsLoading">
        <template #title>
          <Title :title="t('title')">
            <template #left>
              <PfButtonAction
                class="mt-2"
                :label="t('add-cash-register')"
                :icon="ICON_DOWNLOAD"
                has-icon-left
                @click="onAddCashRegisterClick" />
            </template>
          </Title>
        </template>
        <p class="mb-4">{{ t("available-cash-register", { count: cashRegisters.length }) }}</p>
        <ListCashRegister v-if="cashRegisters.length > 0" :cash-registers="cashRegisters" />
        <Component :is="Component" />
      </AppShell>
    </RouterView>
  </Loading>
</template>

<script setup>
import gql from "graphql-tag";
import { useI18n } from "vue-i18n";
import { useQuery, useResult } from "@vue/apollo-composable";
import { onBeforeRouteUpdate, useRouter } from "vue-router";

import { URL_CASH_REGISTER_ADD, URL_CASH_REGISTER } from "@/lib/consts/urls";

import Title from "@/components/app/title";
import ListCashRegister from "@/components/cash-register/list-cash-register";
import Loading from "@/components/app/loading";

const { t } = useI18n();
const router = useRouter();

const {
  result: resultMarkets,
  loading: marketsLoading,
  refetch: refetchCashRegisters
} = useQuery(
  gql`
    query Markets {
      markets {
        id
        name
        cashRegisters {
          id
          name
          isArchived
          marketGroups {
            id
            name
            project {
              id
              name
            }
          }
        }
      }
    }
  `
);
const markets = useResult(resultMarkets);
const cashRegisters = useResult(resultMarkets, [], (data) => {
  return data.markets[0].cashRegisters
    .map((cashRegister) => ({
      id: cashRegister.id,
      name: cashRegister.name,
      isArchived: cashRegister.isArchived,
      marketGroups: cashRegister.marketGroups,
      cashRegisterCanBeDelete: data.markets[0].cashRegisters.filter((x) => !x.isArchived).length > 1
    }))
    .sort((a, b) => a.isArchived - b.isArchived);
});

async function onAddCashRegisterClick() {
  router.push({
    name: URL_CASH_REGISTER_ADD,
    query: { marketId: markets.value[0].id }
  });
}

onBeforeRouteUpdate((to) => {
  if (to.name === URL_CASH_REGISTER) {
    refetchCashRegisters();
  }
});
</script>
